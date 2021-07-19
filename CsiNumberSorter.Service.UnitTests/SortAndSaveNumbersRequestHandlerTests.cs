using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using CsiNumberSorter.Service.RequestHandlers;
using CsiNumberSorter.Service.RequestHandlers.Implementation;
using CsiNumberSorter.DataAccess;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.Service.UnitTests
{
    [TestFixture]
    public class SortAndSaveNumbersRequestHandlerTests
    {
        [Test]
        public async Task WhenNoErrorIsThrownReturnSuccessResponse()
        {
            Mock<IAsyncAddRepository<SortedNumbers>> sortedNumbersAddRepositoryMock = new Mock<IAsyncAddRepository<SortedNumbers>>();

            IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult> systemUnderTest = new SortAndSaveNumbersRequestHandler(sortedNumbersAddRepositoryMock.Object);

            SaveAndSortResult result = await systemUnderTest.RetrieveAsync(new SaveAndSortRequest() { Numbers = new List<int> { 1, 2, 3 }, Ordering = Ordering.Descending });

            Assert.That(result.Success, Is.EqualTo(true));

        }

        [Test]
        public async Task WhenErrorIsThrownReturnFailureResponse()
        {
            Mock<IAsyncAddRepository<SortedNumbers>> sortedNumbersAddRepositoryMock = new Mock<IAsyncAddRepository<SortedNumbers>>();
            sortedNumbersAddRepositoryMock.Setup(x => x.Add(It.IsAny<SortedNumbers>())).Throws(new Exception());

            IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult> systemUnderTest = new SortAndSaveNumbersRequestHandler(sortedNumbersAddRepositoryMock.Object);

            SaveAndSortResult result = await systemUnderTest.RetrieveAsync(new SaveAndSortRequest() { Numbers = new List<int> { 1, 2, 3 }, Ordering = Ordering.Descending });

            Assert.That(result.Success, Is.EqualTo(false));

        }
    }
}
