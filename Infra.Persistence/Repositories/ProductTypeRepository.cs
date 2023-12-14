using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;

namespace Infraestrutura.Repositories
{
    internal class ProductTypeRepository : GenericRepository<ToDo>, IProductTypeRepository
    {

        public ProductTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
