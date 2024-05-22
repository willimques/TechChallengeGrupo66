using Domain.Entities;
using Domain.Entities.Enum;
using Infra.Data.Interfaces;
using System.Data;
using Dapper;

namespace Infra.Data.Repository
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        private readonly IDbConnection _context;
        public ContatoRepository(IDbConnection context) : base(context)
        {            
            _context = context;
        }

        public Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao)
        { 
            var sql = @"SELECT c.*, d.* FROM [dbo].[CONTATOS] c (NOLOCK)
                            JOIN [dbo].[DDD] d (NOLOCK) ON c.DDD_ID=d.id
                        WHERE d.regiao = @idRegiao ";
            
            return _context.QueryAsync<Contato>(sql, new { idRegiao });
        }
    }
}
