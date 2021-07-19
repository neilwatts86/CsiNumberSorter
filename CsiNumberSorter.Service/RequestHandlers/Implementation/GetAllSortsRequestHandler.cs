using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.Domain;
using CsiNumberSorter.DataAccess;
using CsiNumberSorter.DataAccess.Implementation.Specification;

namespace CsiNumberSorter.Service.RequestHandlers.Implementation
{
    public class GetAllSortsRequest : IRequest
    {

    }
    public class GetAllSortsRequestHandler : IAsyncRequestHandler<GetAllSortsRequest, List<SortedNumbers>>
    {
        private IAsyncListRepository<SortedNumbers> _sortedNumbersRepository;

        public GetAllSortsRequestHandler(IAsyncListRepository<SortedNumbers> sortedNumbersRepository)
        {
            _sortedNumbersRepository = sortedNumbersRepository;
        }

        public async Task<List<SortedNumbers>> RetrieveAsync(GetAllSortsRequest Query)
        {
            List<SortedNumbers> sortedNumbersList = await _sortedNumbersRepository.ListAsync(new GetAllSortedNumbers());
            return sortedNumbersList;
        }
    }
}
