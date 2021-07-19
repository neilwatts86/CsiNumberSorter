using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using CsiNumberSorter.Domain.Extensions;
using System.ComponentModel.DataAnnotations;

namespace CsiNumberSorter.Domain
{
    public class SortedNumbers
    {       
        private SortedNumbers()
        {

        }
        public SortedNumbers(IEnumerable<int> numbers, Ordering ordering )
        {
            Ordering = ordering;
            Stopwatch watch = Stopwatch.StartNew();
            Numbers = numbers.Sort(Ordering).ToCsv();
            watch.Stop();
            ElapsedSortTime = watch.ElapsedMilliseconds;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Numbers { get; private set; }
        
        [Required]
        public Ordering Ordering { get; private set; }
        [Required]
        public long ElapsedSortTime { get; private set; }

    }




    public enum Ordering
    {
        Ascending,
        Descending
    }
}
