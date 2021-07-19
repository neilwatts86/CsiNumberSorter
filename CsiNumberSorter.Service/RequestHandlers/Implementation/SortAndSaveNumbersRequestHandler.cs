using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.Domain;
using CsiNumberSorter.DataAccess;
namespace CsiNumberSorter.Service.RequestHandlers.Implementation
{
    public class SaveAndSortRequest : IRequest
    {                      
        public IEnumerable<int> Numbers { get;  set; }
        public Ordering Ordering { get;  set; }
    }

    public class SortAndSaveNumbersRequestHandler : IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult>
    {
        private IAsyncAddRepository<SortedNumbers> _sortedNumbersAddRepository;

        public SortAndSaveNumbersRequestHandler(IAsyncAddRepository<SortedNumbers> sortedNumbersAddRepository)
        {
            _sortedNumbersAddRepository = sortedNumbersAddRepository;
        }

        public async Task<SaveAndSortResult> RetrieveAsync(SaveAndSortRequest query)
        {
            SortedNumbers numbers = new SortedNumbers(query.Numbers, query.Ordering);
            
            try
            {
                _sortedNumbersAddRepository.Add(numbers);
            }
            catch(Exception exception)
            {
                return new SaveAndSortResult(numbers.ElapsedSortTime, false, "Failed to sort and save numbers: " + exception.Message);
            }

            return new SaveAndSortResult(numbers.ElapsedSortTime, true, "Succesfully sorted and saved numbers", numbers.Numbers);




        }
    }
}
