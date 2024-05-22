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
    public class DddRepository : Repository<DDD>, IDddRepository
    {
        public DddRepository(IDbConnection context) : base(context)
        {            
        }

      
    }
}
