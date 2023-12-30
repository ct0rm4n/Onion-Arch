using AutoMapper;
using Application.Repositories;
using Domain.Entities.Concrates;
using Application.ViewModels.ToDo;
using Application;
using Core.Domain.Entities.Concrates.Catalog;
using Application.ViewModels.Post;

namespace Services
{
    public class PostService : GenericService<PostSaveVM, PostVM, Post>, IPostService
    {
        private readonly IPostRepository _repositoryPost;
        public PostService(IGenericRepository<Post> repository, IMapper mapper, IPostRepository repositoryPost) : base(repository, mapper)
        {
            _repositoryPost = repositoryPost;
        }

        public async Task<List<PostVM>> GetList()
        {
            List<PostVM> post = new List<PostVM>();
            List<Post> list = _repositoryPost.GetAllAsIQueryable().ToList();
            foreach (var itemEntity in list)
            {
                post.Add(_mapper.Map<PostVM>(itemEntity));
            }
            return post;
        }
        public async Task<PostVM> CreateOrUpdate(PostVM model)
        {
            Post post = _mapper.Map<Post>(model);
            
            if(post.Id is not 0 && post.Id > 0)
            {
                var old = await _repositoryPost.FirstOrDefaultAsync(x => x.Id == model.Id);
                post.InsertedDate = old.InsertedDate;
                await _repository.UpdateAsync(post);
            }
            else
            {
                await _repository.AddAsync(post);
            }
            return model;
        }

    }
}