using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Infraestrutura.Context;
namespace Infraestrutura.Repositories
{
    internal class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {

        public BannerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
