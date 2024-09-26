using Domain.Entities;
using Domain.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker.Consumer.Events
{
    public class ContatoAddConsumer : IConsumer<Contato>
    {

        private readonly IContatoService _contatoService;
        public ContatoAddConsumer(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        public Task Consume(ConsumeContext<Contato> context)
        {
            var contato = context.Message;
            return _contatoService.Add(contato);
        }
    }
}
