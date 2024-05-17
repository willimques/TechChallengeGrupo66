using Domain.Entities;
using Domain.Entities.Enum;

namespace Infra.Data.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> GetAllByRegionAsync(RegionsType idRegiao);
    }
}
