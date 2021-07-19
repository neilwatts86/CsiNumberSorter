using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiNumberSorter.DataAccess
{
    public interface ISpecification<T>
    {
        IQueryable<T> Query(IQueryable<T> query);
    }
}
