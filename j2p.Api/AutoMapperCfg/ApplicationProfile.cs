using AutoMapper;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels.AddViewModel;
using System;

namespace j2p.Presentation.Api.AutoMapperCfg
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PlayerViewModel, Player>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
        }
    }
}
