using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.Domain.UnitTests
{
    [TestFixture]
    public class SortedNumbersTests
    {
        [Test]
        public void EnumerationOfIntegersIsSortedAndMappedToCsv()
        {
            SortedNumbers numbers = new SortedNumbers(new List<int>() { 1, 2, 3, 4 }, Ordering.Descending);

            Assert.That(numbers.Numbers, Is.EqualTo("4,3,2,1"));
        }

        [Test]
        public void ElapsedSortTimeIsCalculated()
        {
            SortedNumbers numbers = new SortedNumbers(new List<int>() { 1, 2, 3, 4,5,6,7,8,9,10,11,12,13,14,15,16,17,18 }, Ordering.Descending);

            Assert.That(numbers.ElapsedSortTime, Is.GreaterThanOrEqualTo(0));
        }


    }
}
