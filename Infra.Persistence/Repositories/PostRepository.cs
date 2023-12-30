using Application.Repositories;
using Core.Domain.Entities.Concrates.Catalog;
using Domain.Entities.Concrates;
using Infraestrutura.Context;

namespace Infraestrutura.Repositories
{
    internal class PostRepository : GenericRepository<Post>, IPostRepository
    {

        public PostRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
