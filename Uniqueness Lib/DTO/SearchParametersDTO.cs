using System;
using System.Collections.Generic;
using System.Text;

namespace Similarity_Search_Lib.DTO
{
    public class SearchParametersDTO
    {
        public int ResultSize { get; set; }
        public int AllowedPctMissing { get; set; }
        public int SearchWorkerCount { get; set; }
        public SearchTypeENUM SearchType { get; set; }
        public bool CurrentlyDoingWork { get; set; }
    }

    public enum SearchTypeENUM
    {
        Diversity = 0,
        Similarity = 1
    }
}
