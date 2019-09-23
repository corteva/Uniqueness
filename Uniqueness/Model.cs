using Similarity_Search_Lib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Similarity_Search
{
    #region EventDelegates
    public delegate void DataImported();
    public delegate void NewSearchResult();
    public delegate void ParametersChanged();
    #endregion EventDelegates

    public class Model
    {
        public event DataImported dataImportedEvent;
        public event NewSearchResult newSearchResultEvent;
        public event ParametersChanged parametersChangedEvent;

        public Model ()
        {
            this.m_Parameters = new SearchParametersDTO();
            m_Parameters.ResultSize = 15;
            m_Parameters.SearchType = SearchTypeENUM.Diversity;
            m_Parameters.AllowedPctMissing = 5;
            m_Parameters.SearchWorkerCount = System.Environment.ProcessorCount;
            m_Parameters.CurrentlyDoingWork = false;
            if (dataImportedEvent != null) dataImportedEvent();
        }

        #region Parameters
        public int ResultSize { get { return m_Parameters.ResultSize; }
            set
            {
                m_Parameters.ResultSize = value;
                if (parametersChangedEvent != null) parametersChangedEvent();
            }
        }

        public int AllowedPctMissing
        {
            get { return m_Parameters.AllowedPctMissing; }
            set
            {
                m_Parameters.AllowedPctMissing = value;
                if (parametersChangedEvent != null) parametersChangedEvent();
            }
        }

        public int SearchWorkerCount
        {
            get { return m_Parameters.SearchWorkerCount; }
            set
            {
                m_Parameters.SearchWorkerCount = value;
                if (parametersChangedEvent != null) parametersChangedEvent();
            }
        }

        public SearchTypeENUM SearchType
        {
            get { return m_Parameters.SearchType; }
            set
            {
                m_Parameters.SearchType = value;
                if (parametersChangedEvent != null) parametersChangedEvent();
            }
        }

        public int TargetResult { get; set; }
        public bool DoingWork
        {
            get { return m_Parameters.CurrentlyDoingWork; }
            set
            {
                m_Parameters.CurrentlyDoingWork = value;
                if (parametersChangedEvent != null) parametersChangedEvent();
            }
        }
        #endregion Parameters

        private SearchSetDTO m_FullSearchSet;
        public SearchSetDTO fullSearchSet
        {
            get
            {
                return m_FullSearchSet;
            }
            set
            {
                m_FullSearchSet = value;
                if (dataImportedEvent != null) dataImportedEvent();
            }
        }
        public SearchParametersDTO paramaters { get { return m_Parameters; } }
        private SearchParametersDTO m_Parameters;

        private SearchResultDTO m_BestSoFar;
        public SearchResultDTO BestSoFar
        {
            get
            {
                return m_BestSoFar;
            }
            set
            {
                m_BestSoFar = value;
                if (newSearchResultEvent != null && m_BestSoFar != null) newSearchResultEvent();
            }
        }
    }
}
