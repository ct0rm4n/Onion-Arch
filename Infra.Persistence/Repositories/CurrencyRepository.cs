using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Infraestrutura.Context;

namespace Infraestrutura.Repositories
{
    internal class CurrencyRepository : GenericRepository<CurrencyLocale>, ICurrencyRepository
    {

        public CurrencyRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
