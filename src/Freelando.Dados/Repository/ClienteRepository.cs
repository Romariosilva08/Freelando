using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(FreelandoContext context) : base(context)
        {
        }
    }
}