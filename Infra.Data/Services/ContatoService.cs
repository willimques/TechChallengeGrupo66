using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Interfaces;
using Domain.Entities;
using Infra.Data.Repository;

namespace Domain.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            return await _contatoRepository.GetAllAsync();
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            return await _contatoRepository.GetByIdAsync(id);
        }
        public async Task AddAsync(Contato item)
        {
            await _contatoRepository.AddAsync(item);
        }
        public async Task UpdateAsync(Contato item)
        {
            await _contatoRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _contatoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Contato>> GetAllByRegionAsync(int idRegiao)
        {
           return await _contatoRepository.GetAllByRegionAsync(idRegiao);
        }
    }
}
