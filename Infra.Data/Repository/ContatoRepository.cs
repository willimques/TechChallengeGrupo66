using Domain.Entities;
using Domain.Entities.Enum;
using Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(IDbConnection context) : base(context)
        {            
        }

        public Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao)
        {
            throw new NotImplementedException();
        }
    }
}
