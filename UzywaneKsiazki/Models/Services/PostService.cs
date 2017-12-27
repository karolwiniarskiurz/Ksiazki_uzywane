using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UzywaneKsiazki.Models.Services
{
    using AutoMapper;

    using Remotion.Linq.Clauses;

    using UzywaneKsiazki.Extensions;
    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.DTO;
    using UzywaneKsiazki.Models.Repository;

    public class PostService : IPostService
    {
        private IPostRepository repository;

        private IMapper mapper;



        public PostService(IPostRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IQueryable<PostModelDTO> Posts { get; }

        public IEnumerable<PostModelDTO> GetAll()
        {
            var posts = this.repository.Posts;
            return this.mapper.Map<IEnumerable<PostModel>, IEnumerable<PostModelDTO>>(posts);
        }

        public IEnumerable<PostModelDTO> GetBySearchQuery(string searchQuery, int pageNumber)
        {
            searchQuery = searchQuery.RemoveSpacesAndSpecialMarks();
            var posts = this.repository.GetBySearchQuery(searchQuery, pageNumber);
            return this.mapper.Map<IEnumerable<PostModel>, IEnumerable<PostModelDTO>>(posts);
        }

        // todo przetestowac te nizej !!IMPORTANT
        public void AddPost(PostModelDTO post)
        {
            var postModel = this.mapper.Map<PostModelDTO, PostModel>(post);
            //            postModel.Id = Guid.NewGuid();
            postModel.DateOfPosting = DateTime.Now;
            postModel.SearchTags = post.Title.RemoveSpacesAndSpecialMarks();
            this.repository.AddPost(postModel);
        }

        public void DeletePost(Guid id)
        {
            this.repository.DeletePost(id);
        }

        public void UpdatePost(PostModelDTO post)
        {
            this.repository.UpdatePost(this.mapper.Map<PostModelDTO, PostModel>(post));
        }
    }
}