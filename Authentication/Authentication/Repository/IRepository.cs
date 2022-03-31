using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Repository
{
    public interface IRepository<T> where T : class
    {
        public T Add(T item);
        public Task<int> SaveAsync();
    }
}
