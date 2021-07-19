using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace CsiNumberSorter.Website.Models
{
    public class SortedNumbersListItemsViewModel
    {             
        public string ToJson { get { return JsonSerializer.Serialize(SortedNumbersListItems); } }
    
        public List<SortedNumbersListItem> SortedNumbersListItems { get; set; }

    }

    

    public class SortedNumbersListItem
    {
        public string NumbersCsv { get; set; }
        public string Ordering { get; set; }
        public long ElapsedSortTime { get; set; }
    }


}
