using CsiNumberSorter.Models;
using CsiNumberSorter.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CsiNumberSorter.Service.RequestHandlers.Implementation;
using CsiNumberSorter.Service.Mappers;
using CsiNumberSorter.Domain;
using CsiNumberSorter.Service.RequestHandlers;
using CsiNumberSorter.Website.Mappers;

namespace CsiNumberSorter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISortedNumbersViewModelMapper _sortedNumbersViewModelMapper;
        private readonly IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult> _sortAndSaveNumbersRequestHandler;
        private readonly IAsyncRequestHandler<GetAllSortsRequest, List<SortedNumbers>> _getAllSortsRequestHandler;
        private readonly ISaveAndSortRequestMapper _saveAndSortRequestMapper;

        public HomeController(ILogger<HomeController> logger, IAsyncRequestHandler<SaveAndSortRequest, SaveAndSortResult> sortAndSaveNumbersRequestHandler, ISaveAndSortRequestMapper saveAndSortRequestMapper, IAsyncRequestHandler<GetAllSortsRequest, List<SortedNumbers>> getAllSortsRequestHandler, ISortedNumbersViewModelMapper sortedNumbersViewModelMapper)
        {
            _sortAndSaveNumbersRequestHandler = sortAndSaveNumbersRequestHandler;
            _getAllSortsRequestHandler = getAllSortsRequestHandler;
            _saveAndSortRequestMapper = saveAndSortRequestMapper;
            _sortedNumbersViewModelMapper = sortedNumbersViewModelMapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SaveAndSort(string numbersCsv, string ordering)
        {
            SaveAndSortResult result;
            SaveAndSortRequest request;

            //Not ideal to try/catch like this, would switch to using Fluent Validation when implementing in the real world to validate parameters. Would allow for testing also.
            try
            {                
                request = _saveAndSortRequestMapper.Map(numbersCsv, ordering);                              
            }
            catch(Exception exception)
            {
                result = new SaveAndSortResult(-1, false, "Failed to sort and save numbers: " + exception.Message);
                return PartialView("~/Views/Home/_SortedNumbers.cshtml", new SortedNumbersViewModel(result.OrderNumbersCsv, result.ElapsedSortTime, result.Message, result.Success));
            }
            result = await _sortAndSaveNumbersRequestHandler.RetrieveAsync(request);
            return PartialView("~/Views/Home/_SortedNumbers.cshtml", new SortedNumbersViewModel(result.OrderNumbersCsv, result.ElapsedSortTime, result.Message,result.Success));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSorts()
        {
            var result = await _getAllSortsRequestHandler.RetrieveAsync(new GetAllSortsRequest());            
            return PartialView("~/Views/Home/_SortedNumbersList.cshtml", _sortedNumbersViewModelMapper.Map(result));
        }

        [HttpGet]        
        public async Task<IActionResult> ExportToJson()
        {
            var result = await _getAllSortsRequestHandler.RetrieveAsync(new GetAllSortsRequest());
            return PartialView("~/Views/Home/_Json.cshtml", _sortedNumbersViewModelMapper.Map(result));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
