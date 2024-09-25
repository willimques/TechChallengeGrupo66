using Dapper.Contrib.Extensions;
using Domain.Entities;
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

        public Task Add(T item)
        {
            _context.Insert(item);
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            try
            {
                var item = _context.Get<T>(id);

                if (item != null)
                {
                    _context.Delete(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Task.CompletedTask;
        }

        public async Task AddAsync(T item)
        {
           await _context.InsertAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var item = _context.Get<T>(id);

                if (item != null)
                {
                   await _context.DeleteAsync(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.GetAsync<T>(id);
        }

        public Task Update(T item)
        {
            _context.Update(item);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(T item)
        {
            await _context.UpdateAsync(item);
        }
    }
}
