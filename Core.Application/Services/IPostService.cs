using Application;
using Core.Domain.Entities.Concrates.Catalog;
using Application.ViewModels.Post;

namespace Services
{
    public interface IPostService : IGenericService<PostSaveVM, PostVM, Post>
    {
        public Task<List<PostVM>> GetList(bool publish = true);
        public Task<PostVM> CreateOrUpdate(PostVM model);
    }
}
