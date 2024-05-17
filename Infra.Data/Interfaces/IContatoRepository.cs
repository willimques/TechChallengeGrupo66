using Domain.Entities;

namespace Infra.Data.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        Task<IEnumerable<Contato>> GetAllByRegionAsync(int idRegiao);
    }
}
