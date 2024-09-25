using Domain.Entities;
using Domain.Entities.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<Contato>> GetAllAsync();
        Task<Contato> GetByIdAsync(int id);
        Task Add(Contato item);
        Task AddAsync(Contato item);
        Task AddQueueAsync(Contato item);        
        Task Update(Contato item);
        Task UpdateAsync(Contato item);
        Task DeleteQueueAsync(int id);
        Task UpdateQueueAsync(Contato item);
        Task Delete(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao);
    }
}
