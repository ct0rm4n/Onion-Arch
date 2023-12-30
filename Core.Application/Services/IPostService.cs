using Domain.Entities.Concrates;
using Application;
using Application.ViewModels.ToDo;
using Core.Domain.Entities.Concrates.Catalog;
using Application.ViewModels.Post;

namespace Services
{
    public interface IPostService : IGenericService<PostSaveVM, PostVM, Post>
    {
        public Task<List<PostVM>> GetList();
        public Task<PostVM> CreateOrUpdate(PostVM model);
    }
}
