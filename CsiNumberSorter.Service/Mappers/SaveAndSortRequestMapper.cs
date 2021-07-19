using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.Service.RequestHandlers.Implementation;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.Service.Mappers
{
    public interface ISaveAndSortRequestMapper
    {
        SaveAndSortRequest Map(string numbersCsv, string ordering);
    }
    public class SaveAndSortRequestMapper : ISaveAndSortRequestMapper
    {
        public SaveAndSortRequest Map(string numbersCsv, string ordering)
        {
            if(!Enum.TryParse(ordering, out Ordering orderingEnum))
            {
                throw new InvalidCastException("Unable to parse to Ordering enum: " + ordering);
            };

            IEnumerable<int> numbers;
            try
            {
                numbers = numbersCsv.Split(",").Select(int.Parse).ToList();
            }
            catch(Exception exception)
            {
                throw new Exception("Unable to split numbers from the input", exception);
            }

            return new SaveAndSortRequest()
            {
                Numbers = numbers,
                Ordering = orderingEnum
            };
        }
    }
}
