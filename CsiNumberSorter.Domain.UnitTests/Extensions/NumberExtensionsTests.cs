using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CsiNumberSorter.Domain.Extensions;
namespace CsiNumberSorter.Domain.UnitTests.Extensions
{
    [TestFixture]
    public class NumberExtensionsTests
    {
        
        [TestCaseSource(typeof(Enumerations), nameof(Enumerations.TestCases))]
        public void IEnumerableSortedtoOrdering(IEnumerable<int> enumerable, Ordering ordering, IEnumerable<int> expectedEnumerable)
        {
            Assert.That(enumerable.Sort(ordering), Is.EquivalentTo(expectedEnumerable));
        }
    }

    public class Enumerations
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new List<int>() { 1, 2, 3, 4, 5 }, Ordering.Ascending, new List<int>() { 1, 2, 3, 4, 5 }).SetName("AscendingToAscending");
                yield return new TestCaseData(new List<int>() { 3, 4, 1, 2, 5 }, Ordering.Ascending, new List<int>() { 1, 2, 3, 4, 5 }).SetName("UnorderedToAscending");
                yield return new TestCaseData(new List<int>() { 1, 2, 3, 4, 5 }, Ordering.Descending, new List<int>() { 5, 4, 3, 2, 1 }).SetName("AscendingToDescending");
                yield return new TestCaseData(new List<int>() { 3, 4, 1, 2, 5 }, Ordering.Descending, new List<int>() { 5, 4, 3, 2, 1 }).SetName("UnorderedToDescending");
                yield return new TestCaseData(new List<int>() { 5, 4, 3, 2, 1 }, Ordering.Descending, new List<int>() { 5, 4, 3, 2, 1 }).SetName("DescendingToDescending");
                yield return new TestCaseData(new List<int>() { 5, 4, 3, 2, 1 }, Ordering.Ascending, new List<int>() { 1, 2, 3, 4, 5 }).SetName("DescendingToAscending");

            }
        }
    }
}
