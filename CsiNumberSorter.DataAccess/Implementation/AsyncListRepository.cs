using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CsiNumberSorter.DataAccess.Implementation
{
    public class AsyncListRepository<T> : IAsyncListRepository<T> where T: class
    {
        private readonly DbContext _dbContext;

        public AsyncListRepository(DbContext dbContext) => this._dbContext = dbContext;
        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = spec.Query(query);

            List<T> listAsync = await query.ToListAsync(new System.Threading.CancellationToken());

            return listAsync;

        }
    }
}
