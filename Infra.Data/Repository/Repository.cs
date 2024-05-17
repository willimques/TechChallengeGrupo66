using Dapper.Contrib.Extensions;
using Infra.Data.Interfaces;
using System.Data;


namespace Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly IDbConnection _context;

        public Repository(IDbConnection context)
        {
            _context = context;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.GetAllAsync<T>();
        }

        public async Task AddAsync(T item)
        {
            await _context.InsertAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.GetAsync<T>(id);

            if (item != null)
            {
                await _context.DeleteAsync(item);
            }
        }

       
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.GetAsync<T>(id);
        }

        public async Task UpdateAsync(T item)
        {
            await _context.UpdateAsync(item);            
        }
    }
}
