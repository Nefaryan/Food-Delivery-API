using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task Create (T entity);
        public Task Update (Guid Id,T entity);
        public Task<List<T>> GetAll ();
        public Task<T> GetSingle (Guid Id);
        public Task<string> Delete (Guid Id);
    }
}
