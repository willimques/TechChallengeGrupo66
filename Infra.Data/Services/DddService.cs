using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Interfaces;
using Domain.Entities;
using Infra.Data.Repository;
using Domain.Entities.Enum;

namespace Domain.Services
{
    public class DddService : IDddService
    {

        private readonly IDddRepository _dddRepository;

        public DddService(IDddRepository dddRepository)
        {
            _dddRepository = dddRepository;
        }

        public async Task<IEnumerable<DDD>> GetAllAsync()
        {
            return await _dddRepository.GetAllAsync();
        }

        public async Task<DDD> GetByIdAsync(int id)
        {
            return await _dddRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(DDD item)

        {
          
            await _dddRepository.AddAsync(item);
        }
        public async Task UpdateAsync(DDD item)
        {
            await _dddRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _dddRepository.DeleteAsync(id);
        }

        
    }
}
