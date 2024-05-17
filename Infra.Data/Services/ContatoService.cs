using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Data.Interfaces;
using Domain.Entities;

namespace Domain.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<IEnumerable<Contato>> GetAll()
        {
          return await _contatoRepository.GetAllAsync();
        }
    }
}
