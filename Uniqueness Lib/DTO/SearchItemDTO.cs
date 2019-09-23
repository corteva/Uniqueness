using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Similarity_Search_Lib.DTO
{
    public class SearchItemDTO
    {
        public SearchItemDTO(string uniqueid, string alias, bool required, string[] datapoints, string raw)
        {
            this.UniqueID = uniqueid;
            this.Required = required;
            this.Datapoints = datapoints;
            this.Raw = raw;
            int missingcount = Datapoints.Where(x => string.IsNullOrEmpty(x)).Count();
            int totalcount = Datapoints.Count();
            this.PctMissing = (((double)missingcount) / ((double)totalcount)) * 100; ;
            this.Alias = alias;
        }
        public string UniqueID { get; set; }
        public string Alias { get; set; }
        public bool Required { get; set; }
        public string[] Datapoints { get; set; }
        public double PctMissing { get; private set; }
        public string Raw { get; set; }
    }
}