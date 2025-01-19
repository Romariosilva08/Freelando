using Freelando.Dados.Repository;
using Freelando.Dados.Repository.@base;
using Freelando.Modelo;

namespace Freelando.Dados.UnitOfWork
{
    public class CandidaturaRepository : Repository<Candidatura>, ICandidaturaRepository
    {
        public CandidaturaRepository(FreelandoContext context) : base(context)
        {
        }
    }
}