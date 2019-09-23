using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Similarity_Search_Lib.DTO
{
    public class SearchResultDTO
    {
        public List<SearchItemDTO> Items { get; set; }
        public int Result { get; set; }
        public double PctMissingSum
        {
            get
            {
                return (from item in Items select item.PctMissing).Sum();
            }
        }

        public bool IsBetterThan(SearchResultDTO that, Similarity_Search_Lib.DTO.SearchTypeENUM method)
        {
            if (method == SearchTypeENUM.Diversity)
            {
                // Higher result # is "better"
                if (this.Result < that.Result)
                    return false;
                else if (this.Result > that.Result)
                    return true;
                else
                    return (this.PctMissingSum <= that.PctMissingSum); // Tie breaker
            }
            else
            {
                // Lower result # is "better"
                if (this.Result < that.Result)
                    return true;
                else if (this.Result > that.Result)
                    return false;
                else
                    return (this.PctMissingSum <= that.PctMissingSum); // Tie breaker
            }
        }
    }
}
