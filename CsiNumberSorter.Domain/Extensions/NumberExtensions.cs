using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiNumberSorter.Domain.Extensions
{
    public static class NumberExtentions
    {
        public static IEnumerable<int> Sort(this IEnumerable<int> numbers, Ordering ordering)
        {
            return (ordering == Ordering.Ascending) ? numbers.OrderBy(e => e) : numbers.OrderByDescending(e => e);
        }

        public static string ToCsv(this IEnumerable<int> numbers)
        {
            return string.Join(",", numbers);
        }

    }

}
