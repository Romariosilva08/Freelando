using Freelando.Dados.Repository;
using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.UnitOfWork
{
    public class ContratoRepository : Repository<Contrato>, IContratoRepository
    {
        public ContratoRepository(FreelandoContext context) : base(context)
        {
        }
    }
}