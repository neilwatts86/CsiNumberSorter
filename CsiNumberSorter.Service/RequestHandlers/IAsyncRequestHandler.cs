using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiNumberSorter.Service.RequestHandlers
{
    public interface IAsyncRequestHandler<in TRequest, TResponse> where TRequest : IRequest
    {
        Task<TResponse> RetrieveAsync(TRequest Query);
    }
}
