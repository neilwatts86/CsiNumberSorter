using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiNumberSorter.Domain
{
    public class SaveAndSortResult
    {
        public SaveAndSortResult(long elapsedSortTime, bool success, string message, string orderNumbersCsv) : this(elapsedSortTime, success, message)
        {
            OrderNumbersCsv = orderNumbersCsv;
        }
        public SaveAndSortResult(long elapsedSortTime, bool success, string message)
        {
            ElapsedSortTime = elapsedSortTime;
            Success = success;
            Message = message;
        }

        public long ElapsedSortTime { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string OrderNumbersCsv { get; private set; }
    }
}
