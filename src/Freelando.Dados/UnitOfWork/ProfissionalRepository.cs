using Freelando.Dados.Repository;
using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.UnitOfWork
{
    public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository

    {
        public ProfissionalRepository(FreelandoContext context) : base(context)
        {
        }
    }
}