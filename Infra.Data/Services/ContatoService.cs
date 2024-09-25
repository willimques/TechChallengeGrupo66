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
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MassTransit;

namespace Domain.Services
{
    public class ContatoService : IContatoService
    {

        private readonly IContatoRepository _contatoRepository;
        private readonly IDddRepository _dddRepository;
        private readonly IBus _bus;

        public ContatoService(IContatoRepository contatoRepository, IDddRepository dddRepository, IBus bus)
        {
            _contatoRepository = contatoRepository;
            _dddRepository = dddRepository;
            _bus = bus;

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
            var _ddd_id = _dddRepository.GetByIdAsync(item.DDD_ID).Result;

            if (_ddd_id == null)
            {
                throw new Exception("DDD não encontrado");
            }
            else
            {
                await _contatoRepository.AddAsync(item);
            }
        }

        public async Task AddQueueAsync(Contato item)
        {
            var _ddd_id = _dddRepository.GetByIdAsync(item.DDD_ID).Result;

            if (_ddd_id == null)
            {
                throw new Exception("DDD não encontrado");
            }
            else
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Contato.Queue.Add"));
                await endpoint.Send(item);
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

        public async Task UpdateQueueAsync(Contato item)
        {
            var _ddd_id = _dddRepository.GetByIdAsync(item.DDD_ID).Result;

            if (_ddd_id == null)
            {
                throw new Exception("DDD não encontrado");
            }
            else
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Contato.Queue.Update"));
                await endpoint.Send(item);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _contatoRepository.DeleteAsync(id);
        }

        public async Task DeleteQueueAsync(int id)
        {
            var item = await _contatoRepository.GetByIdAsync(id);
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Contato.Queue.Delete"));
            await endpoint.Send(item);
        }

        public async Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao)
        {
            return await _contatoRepository.GetAllByRegionAsync(idRegiao);
        }
    }
}
