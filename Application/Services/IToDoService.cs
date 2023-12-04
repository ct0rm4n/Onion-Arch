using Domain.Entities.Concrates;
using Application;
using Application.ViewModels.ToDo;

namespace Services
{
    public interface IToDoService : IGenericService<ToDoSaveVM, ToDoVM, ToDo>
    {
        public Task<List<ToDoVM>> GetList();
        public Task<ToDoVM> CreateOrUpdate(ToDoVM model);
    }
}
