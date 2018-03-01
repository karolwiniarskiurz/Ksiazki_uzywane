using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UzywaneKsiazki.Helpers.Exceptions;

namespace UzywaneKsiazki.Models.Services
{
    using AutoMapper;
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

        public async Task<PostModelDTO> GetByIdAsync(int id)
        {
            var post = await this.repository.GetByIdAsync(id);
            if (post == null) // using this if to reduce calls to database
            {
                throw new PostNotFoundException("Ogłoszenie nie istnieje");
            }

            var postDTO = this.mapper.Map<PostModelDTO>(post);
            return postDTO;
        }

        public async Task<IEnumerable<PostModelDTO>> GetBySearchQueryAsync(string searchQuery, int pageNumber)
        {
            searchQuery = searchQuery.RemoveSpacesAndSpecialMarks();
            var posts = await this.repository.GetBySearchQueryAsync(searchQuery, pageNumber);
            return this.mapper.Map<IEnumerable<PostModel>, IEnumerable<PostModelDTO>>(posts);
        }

        // todo przetestowac te nizej !!IMPORTANT
        public async Task AddPostAsync(PostModelDTO post)
        {
            var postModel = this.mapper.Map<PostModelDTO, PostModel>(post);
            postModel.CheckValuesOrThrowException();
            postModel.GenerateValues();
            
            await this.repository.AddPostAsync(postModel);
        }

        public async Task DeletePostAsync(int id)
        {
            if (await this.repository.GetByIdAsync(id) == null)
            {
                throw new PostNotFoundException("Ogłoszenie nie istnieje");
            }

            await this.repository.DeletePostAsync(id);
        }

        public async Task UpdatePostAsync(PostModelDTO post)
        {
            await IsPostWithGivenIdValidElseThrowException(post.Id);
            var postMapped = this.mapper.Map<PostModelDTO, PostModel>(post);
            postMapped.GenerateValues();
            await this.repository.UpdatePostAsync(postMapped);
        }

        private async Task IsPostWithGivenIdValidElseThrowException(int id)
        {
            if (await this.repository.GetByIdAsync(id) == null)
            {
                throw new PostNotFoundException("Ogłoszenie nie istnieje");
            }
        }

#if DEBUG
        public IEnumerable<PostModelDTO> GetAll()
        {
            var posts = this.repository.Posts;
            return this.mapper.Map<IEnumerable<PostModel>, IEnumerable<PostModelDTO>>(posts);
        }
#endif
    }
}