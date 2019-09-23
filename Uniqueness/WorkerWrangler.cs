using Similarity_Search_Lib;
using Similarity_Search_Lib.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity_Search
{
    public class WorkerWrangler
    {
        private Model m_model;
        List<SearchWorker> m_workers=new List<SearchWorker>();
        public WorkerWrangler(Model m)
        {
            this.m_model = m;
            for (int i = 0; i < this.m_model.SearchWorkerCount; i++)
            {
                var worker = new SearchWorker(m_model.fullSearchSet, m_model.paramaters);
                worker.BestResultFoundEvent += FoundBest;
                worker.Start(m_model.BestSoFar);
                m_workers.Add(worker);
                m_model.BestSoFar = null;
            } 
        }

        public void Stop()
        {
            foreach(var worker in m_workers)
            {
                worker.Stop();
            }
            m_workers.Clear();
        }

        public long GetIterationCount()
        {
            if (m_workers == null || m_workers.Count() == 0)
                return 0;
            return m_workers.Select(x => x.NumberofIterations()).Sum();
        }

        private void FoundBest(SearchResultDTO workerResult)
        {
            if (m_model.BestSoFar == null)
                m_model.BestSoFar = workerResult;
            else
            {
                if (!m_model.BestSoFar.IsBetterThan(workerResult, m_model.SearchType))
                {
                    m_model.BestSoFar = workerResult;
                }
            }
        }
    }
}
