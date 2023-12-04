using AutoMapper;
using Application.Repositories;
using Domain.Entities.Concrates;
using Application.ViewModels.ToDo;
using Application;

namespace Services
{
    public class ToDoService : GenericService<ToDoSaveVM, ToDoVM, ToDo>, IToDoService
    {
        private readonly IToDoRepository _categoryRepository;
        public ToDoService(IGenericRepository<ToDo> repository, IMapper mapper, IToDoRepository categoryRepository) : base(repository, mapper)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ToDoVM>> GetList()
        {
            List<ToDoVM> categorVMs = new List<ToDoVM>();
            List<ToDo> list = _categoryRepository.GetAllAsIQueryable().ToList();
            foreach (var itemEntity in list)
            {
                categorVMs.Add(_mapper.Map<ToDoVM>(itemEntity));
            }
            return categorVMs;
        }
        public async Task<ToDoVM> CreateOrUpdate(ToDoVM model)
        {
            ToDo appToDo = _mapper.Map<ToDo>(model);
            
            if(appToDo.Id is not 0 && appToDo.Id > 0)
            {
                var old = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == model.Id);
                appToDo.InsertedDate = old.InsertedDate;
                await _repository.UpdateAsync(appToDo);
            }
            else
            {
                await _repository.AddAsync(appToDo);
            }
            return model;
        }

    }
}