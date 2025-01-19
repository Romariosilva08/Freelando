using Freelando.Dados.Repository;
using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.UnitOfWork
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(FreelandoContext context) : base(context)
        {
        }
    }
}