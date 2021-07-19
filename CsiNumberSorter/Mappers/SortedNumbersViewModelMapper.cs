using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsiNumberSorter.Domain;
using CsiNumberSorter.Website.Models;

namespace CsiNumberSorter.Website.Mappers
{
    public interface ISortedNumbersViewModelMapper
    {
        SortedNumbersListItemsViewModel Map(List<SortedNumbers> sortedNumbersList);
    }
    public class SortedNumbersViewModelMapper : ISortedNumbersViewModelMapper
    {
        public SortedNumbersListItemsViewModel Map(List<SortedNumbers> sortedNumbersList)
        {
            var sortedNumbersListItems = new List<SortedNumbersListItem>();
            foreach (var sortedNumbers in sortedNumbersList)
            {
                SortedNumbersListItem item = new SortedNumbersListItem()
                {
                    ElapsedSortTime = sortedNumbers.ElapsedSortTime,
                    NumbersCsv = sortedNumbers.Numbers,
                    Ordering = (sortedNumbers.Ordering == Ordering.Ascending) ? "Ascending" : "Descending"
                };

                sortedNumbersListItems.Add(item);
            }

            return new SortedNumbersListItemsViewModel() { SortedNumbersListItems = sortedNumbersListItems};
        }
    }
}
