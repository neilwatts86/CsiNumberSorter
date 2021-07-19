using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.DataAccess;

namespace CsiNumberSorter.DataAccess.Implementation.Specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public virtual IQueryable<T> Query(IQueryable<T> query) => query;
        
    }
}
