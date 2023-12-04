using Application.Repositories;
using Domain.Entities.Concrates;
using Infraestrutura.Context;

namespace Infraestrutura.Repositories
{
    internal class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {

        public ToDoRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
