using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsiNumberSorter.Website.Models
{
    public class SortedNumbersViewModel
    {
        public SortedNumbersViewModel(string numbersCsv, long elapsedSortTime, string message, bool success) 
        {
            NumbersCsv = numbersCsv;
            ElapsedSortTime = elapsedSortTime;
            Message = message;
            AlertClass = (success) ? "alert alert-success" : "alert alert-danger";
        }

        public string NumbersCsv { get; set; }
        public long ElapsedSortTime { get; set; }
        public string Message { get; set; }
        public string AlertClass { get; set; }
    }
}
