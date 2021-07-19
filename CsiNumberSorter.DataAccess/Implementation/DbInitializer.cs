using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.Domain;
using Microsoft.EntityFrameworkCore;

namespace CsiNumberSorter.DataAccess.Implementation
{
    public static class DbInitializer
    {
        public static void Initialize(NumbersUnitOfWork context)
        {
            context.Database.EnsureCreated();

            if (context.SortedNumbers.Any())
            {
                return;
            }

            SortedNumbers sortedNumber1 = new SortedNumbers(new List<int>() { 1, 2, 3, 4 }, Ordering.Ascending);
            SortedNumbers sortedNumber2 = new SortedNumbers(new List<int>() { 1, 2, 3, 4 }, Ordering.Descending);

            var sortedNumberList = new SortedNumbers[]
            {
                sortedNumber1,sortedNumber2
            };

            foreach (SortedNumbers sortedNumbers  in sortedNumberList)
            {
                context.SortedNumbers.Add(sortedNumbers);
            }

            context.SaveChanges();

  
        }
    }
}
