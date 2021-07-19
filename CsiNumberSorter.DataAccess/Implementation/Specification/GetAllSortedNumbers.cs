using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsiNumberSorter.Domain;

namespace CsiNumberSorter.DataAccess.Implementation.Specification
{
    public class GetAllSortedNumbers : BaseSpecification<SortedNumbers>
    {
        public override IQueryable<SortedNumbers> Query(IQueryable<SortedNumbers> query)
        {
            return query;
        }
    }
}
