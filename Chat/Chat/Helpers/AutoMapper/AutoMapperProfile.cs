using AutoMapper;
using Chat.Models;
using Chat.Models.AuthorizationViewModels;

namespace Chat.Helpers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.FirstName, x => x.MapFrom(m => m.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(m => m.LastName))
                .ForMember(x => x.Email, x => x.MapFrom(m => m.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(m => $"{m.FirstName}{m.LastName}"))
                .ForMember(x => x.Birthday, x => x.MapFrom(x => x.Birthday));
        }
    }
}
