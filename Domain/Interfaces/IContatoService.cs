using Domain.Entities;
using System;
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
        Task AddAsync(Contato item);
        Task UpdateAsync(Contato item);
        Task DeleteAsync(int id);
        Task<IEnumerable<Contato>> GetAllByRegionAsync(int idRegiao);
    }
}
