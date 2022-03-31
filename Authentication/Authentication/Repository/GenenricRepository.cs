using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Repository
{
    public class GenenricRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenenricRepository(AppDbContext context)
        {
            this.context = context;
        }


        public T Add(T item)
        {
            return context.Add(item).Entity;
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
