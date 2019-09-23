using Similarity_Search_Lib.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Similarity_Search_Lib
{
    public static class FileHandler
    {
        public static SearchSetDTO Import(string filepath)
        {
            var ResultSet = new SearchSetDTO();
            var file = File.ReadAllLines(filepath);
            var headertext = file.First();
            ResultSet.InputFilename = filepath;
            ResultSet.Header = headertext;
            bool istabsplit;
            var commaheader = headertext.Split(',');
            var tabheader = headertext.Split('\t');
            string[] header;
            if (commaheader.Count()> tabheader.Count())
            {
                istabsplit = false;
                header = commaheader;                
            }
            else
            {
                istabsplit = true;
                header = tabheader;
            }
            try
            {
                ResultSet.Items = file.Skip(1).AsParallel().Select(item =>
                {
                    string[] elements;
                    if (istabsplit)
                        elements = item.Split('\t');
                    else
                        elements = item.Split(',');
                    if (elements.Count() != header.Count())
                        throw new FileFormatException("Count mismatch in file");
                    var uniqueid = elements[0].Trim();
                    var alias = elements[1].Trim();
                    bool required = false;
                    var requiredstring = elements[2].Trim().ToUpper();
                    if (requiredstring.StartsWith("T") || requiredstring == "1")
                        required = true;
                    SearchItemDTO searchitem = new SearchItemDTO(uniqueid, alias, required, elements.Skip(3).Select(x => x.Trim()).ToArray(), item);
                    return searchitem;
                }).ToList();
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }
            return ResultSet;
        }
        public static void Export(SearchResultDTO result,SearchSetDTO startingset, string filepath)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath))
            {
                file.WriteLine(startingset.Header);
                foreach (var item in result.Items)
                {
                    file.WriteLine(item.Raw);
                }
            }
        }
    }

}
