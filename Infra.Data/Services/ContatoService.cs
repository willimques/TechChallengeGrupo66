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
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;
        private readonly IDddRepository _dddRepository;

        public ContatoService(IContatoRepository contatoRepository, IDddRepository dddRepository)
        {
            _contatoRepository = contatoRepository;
            _dddRepository = dddRepository; 
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
           var _ddd_id  = _dddRepository.GetByIdAsync(item.DDD_ID).Result;

            if (_ddd_id == null)
            {
                throw new Exception("DDD não encontrado");
            }
            else
            {
                await _contatoRepository.AddAsync(item);
            }
        }

        public async Task UpdateAsync(Contato item)
        {
            var _ddd_id = _dddRepository.GetByIdAsync(item.DDD_ID).Result;

            if (_ddd_id == null)
            {
                throw new Exception("DDD não encontrado");
            }
            else
            {
                await _contatoRepository.UpdateAsync(item);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _contatoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao)
        {
           return await _contatoRepository.GetAllByRegionAsync(idRegiao);
        }
    }
}
