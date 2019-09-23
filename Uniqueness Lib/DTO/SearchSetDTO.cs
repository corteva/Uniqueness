using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Similarity_Search_Lib.DTO
{
    public class SearchSetDTO
    {
        public SearchSetDTO()
        {
            this.Items = new List<SearchItemDTO>();
        }
        public string InputFilename { get; set; }
        public string Header { get; set; }
        public List<SearchItemDTO> Items { get; set; }
        public IEnumerable<SearchItemDTO> GetFilteredItems (int pctMissing)
        {
            return this.Items.Where(x => x.PctMissing < pctMissing).ToList();
        }
    }
}
