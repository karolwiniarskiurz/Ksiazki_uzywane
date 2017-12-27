namespace UzywaneKsiazki.Models.Mapper
{
    using AutoMapper;

    using UzywaneKsiazki.Models.DomainModels;
    using UzywaneKsiazki.Models.DTO;

    public class PostMapperProfile : Profile
    {
        public PostMapperProfile()
        {
            this.CreateMap<PostModel, PostModelDTO>();
            this.CreateMap<PostModelDTO, PostModel>();
        }
    }
}