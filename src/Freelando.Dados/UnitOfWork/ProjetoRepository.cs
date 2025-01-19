using Freelando.Dados.Repository;
using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.UnitOfWork
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(FreelandoContext context) : base(context)
        {
        }
    }
}