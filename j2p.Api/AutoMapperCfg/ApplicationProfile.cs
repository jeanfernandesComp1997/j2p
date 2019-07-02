using AutoMapper;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels;

namespace j2p.Presentation.Api.AutoMapperCfg
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PlayerViewModel, Player>();
        }
    }
}
