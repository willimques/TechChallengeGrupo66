using Domain.Entities;
using Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface IDddService
    {
        Task<IEnumerable<DDD>> GetAllAsync();
        Task<DDD> GetByIdAsync(int id);
        Task AddAsync(DDD item);
        Task UpdateAsync(DDD item);
        Task DeleteAsync(int id);
       
    }
}
