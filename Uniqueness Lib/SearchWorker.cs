using Similarity_Search_Lib.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace Similarity_Search_Lib
{
    #region EventDelegates
    public delegate void BestResultFound(SearchResultDTO res);
    #endregion EventDelegates

    public class SearchWorker
    {
        #region privateVars
        private object m_lock = new object();
        private SearchSetDTO m_Data;
        private SearchParametersDTO m_SearchParams;
        private List<SearchItemDTO> m_Filtered;
        private SearchResultDTO m_BestResult;
        private long m_workcount = 1;
        private bool m_keepworking = true;
        private TaskScheduler m_sched;
        private Random RandomNumber = new Random();
        #endregion
        public event BestResultFound BestResultFoundEvent;

        public SearchWorker(SearchSetDTO data, SearchParametersDTO searchparams)
        {
            m_Data = data;
            m_Filtered = m_Data.GetFilteredItems(searchparams.AllowedPctMissing).ToList();
            m_SearchParams = searchparams;
            m_sched = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();
        }

        [MTAThread]
        public void Start(SearchResultDTO previousBestIfExists)
        {
            new Thread(() =>
              {
                  while (m_keepworking)
                  {
                      this.DoWork(previousBestIfExists);                      
                  }
              }).Start();
        }

        public SearchResultDTO GetResult()
        {
            lock (m_lock)
            {
                return m_BestResult;
            }
        }

        public long NumberofIterations()
        {
            return m_workcount;
        }

        private void DoWork(SearchResultDTO previousBestIfExists)
        {
            var candidateSetDictionary = new Dictionary<string, SearchItemDTO>();

            if (previousBestIfExists != null)
            {
                foreach (var item in previousBestIfExists.Items)
                {
                    if (item.Required || item.PctMissing < m_SearchParams.AllowedPctMissing)
                    {
                        if (candidateSetDictionary.Count < m_SearchParams.ResultSize)
                        {
                            candidateSetDictionary[item.UniqueID] = item;
                        }
                    }
                    if (item.Required) candidateSetDictionary[item.UniqueID] = item;
                }
            }

            foreach(var item in m_Data.Items) if (item.Required) candidateSetDictionary[item.UniqueID] = item;

            int loops = 0;
            while (candidateSetDictionary.Count < m_SearchParams.ResultSize)
            {
                var candidate = PickRandomItem();
                if (!candidateSetDictionary.ContainsKey(candidate.UniqueID)) candidateSetDictionary[candidate.UniqueID] = candidate;
                loops++;
                if (loops > m_Data.Items.Count * 10) throw new Exception("wtf");
            }

            // Got starting set and make it the best so far
            m_BestResult = new SearchResultDTO();
            m_BestResult.Items = candidateSetDictionary.Values.ToList();
            m_BestResult.Result = Measure(m_BestResult.Items);
            new System.Threading.Tasks.Task(() => BestResultFoundEvent(m_BestResult)).Start(m_sched);

            while (m_keepworking)
            {
                loops = 0;
                SearchItemDTO candidate = null;
                while (candidate == null)
                {
                    loops++;
                    if (loops > m_Data.Items.Count * 10) throw new Exception("wtf");
                    var temp = PickRandomItem();
                    if (!candidateSetDictionary.ContainsKey(temp.UniqueID)) candidate = temp;
                }

                // We have a new candidate, try it out in every slot and measure
                var testArray = candidateSetDictionary.Values.ToArray();
                int improved = 0;
                for (int idx = 0; idx < candidateSetDictionary.Keys.Count; idx++)
                {
                    var itemSubbedOut = testArray[idx];
                    if (!itemSubbedOut.Required)
                    {
                        testArray[idx] = candidate;
                        var candidateResult = new SearchResultDTO();
                        candidateResult.Items = testArray.ToList();
                        candidateResult.Result = Measure(candidateResult.Items);

                        if (!m_BestResult.IsBetterThan(candidateResult, m_SearchParams.SearchType) || RandomNumber.Next(100000) == 66666)
                        {
                            m_BestResult = candidateResult;
                            improved++;
                            new System.Threading.Tasks.Task(() => BestResultFoundEvent(m_BestResult)).Start(m_sched);
                        }
                        testArray[idx] = itemSubbedOut;
                    }
                }

                if (improved > 0)
                {
                    candidateSetDictionary.Clear();
                    foreach (var item in m_BestResult.Items) candidateSetDictionary[item.UniqueID] = item;
                    loops++;
                    if (loops > m_Data.Items.Count * 10) throw new Exception("wtf");
                }
            }
        }

        private int Measure(IEnumerable<SearchItemDTO> items)
        {
            if (m_SearchParams.SearchType == SearchTypeENUM.Diversity)
                return DiversityMeasure(items);
            else
                return SimilarityMeasure(items);
        }


        private int SimilarityMeasure(IEnumerable<SearchItemDTO> items)
        {
            Interlocked.Increment(ref m_workcount);
            int itemCount = items.Count();
            var totalNonMajority = 0;
            int columnCount = items.First().Datapoints.Count();
            for (int col = 0; col < columnCount; col++)
            {
                var dataPointDictionary = new Dictionary<string, int>();
                foreach (var item in items)
                {
                    int reward = item.Required ? itemCount : 1; //if the item is required, we should reward it so we will cluster around it
                    if(dataPointDictionary.TryGetValue(item.Datapoints[col],out int value))
                        dataPointDictionary[item.Datapoints[col]] = reward + value;
                    else
                        dataPointDictionary[item.Datapoints[col]] = reward;
                }
                totalNonMajority += (dataPointDictionary.Values.Sum() - dataPointDictionary.Values.Max());
            }
            return totalNonMajority;
        }


        private int DiversityMeasure(IEnumerable<SearchItemDTO> items)
        {
            Interlocked.Increment(ref m_workcount);
            var sigDictionary = new Dictionary<string, int>();
            int columnCount = items.First().Datapoints.Count();
            for (int col = 0; col < columnCount; col++)
            {
                var sig=String.Join(".", items.Select(x => x.Datapoints[col]));
                if (sigDictionary.TryGetValue(sig, out int val))
                    sigDictionary[sig]=val+1;
                else
                    sigDictionary.Add(sig, 1);
            }
            return sigDictionary.Values.Where(x => x == 1).Count();
        }

        private SearchItemDTO PickRandomItem()
        {
            int random = Convert.ToInt32(this.RandomNumber.Next(m_Filtered.Count));
            return m_Filtered[random];
        }

        public void Stop()
        {
            lock (m_lock)
            {
                m_keepworking = false;
            }
        }
    }
}
