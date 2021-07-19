using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CsiNumberSorter.DataAccess.Implementation.Specification;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.DataAccess.UnitTests
{
 
    [TestFixture]
    public class GetAllSortedNumbersTest
    {
        [Test]
        public void AllSortedNumbersAreReturned()
        {
            GetAllSortedNumbers getAllSortedNumbers = new GetAllSortedNumbers();

            List<SortedNumbers> sortedNumbers = new List<SortedNumbers>()
            {
                new SortedNumbers(new List<int>(){1,2,3 },Ordering.Ascending),
                new SortedNumbers(new List<int>(){1,2,3 },Ordering.Descending),
                new SortedNumbers(new List<int>(){1,2,3,4,5,6,7 },Ordering.Descending)
            };

            var result =  getAllSortedNumbers.Query(sortedNumbers.AsQueryable());

            Assert.That(result.Count, Is.EqualTo(3));
        }

    }
}
