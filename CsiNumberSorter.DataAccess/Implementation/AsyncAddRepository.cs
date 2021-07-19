using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsiNumberSorter.DataAccess.Implementation
{
    public class AsyncAddRepository<T> : IAsyncAddRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public AsyncAddRepository(DbContext dbcontext) => _dbContext = dbcontext;
        public void Add(T entity) 
        {

            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }
    }

}
