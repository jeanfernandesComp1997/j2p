using AutoMapper;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels;
using j2p.Presentation.Api.ViewModels.AddViewModel;
using System;

namespace j2p.Presentation.Api.AutoMapperCfg
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PlayerViewModel, Player>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
            CreateMap<Player, PlayerViewModel>().AfterMap((src, dest) => {
                dest.Password = string.Empty;
            });

            CreateMap<EventViewModel, Event>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
            CreateMap<Event, EventViewModel>().AfterMap((src, dest) => {
                dest.Owner.Id = Guid.Empty;
                dest.Owner.Password = string.Empty;
                dest.Owner.Email = string.Empty;
                dest.Owner.Events = null;

                dest.Local.Owner = null;
            });

            CreateMap<LocalViewModel, Local>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
            CreateMap<Local, LocalViewModel>().AfterMap((src, dest) => {
                dest.Owner.Id = Guid.Empty;
                dest.Owner.Password = string.Empty;
                dest.Owner.Cpf = string.Empty;
                dest.Owner.Cnpj = string.Empty;
            });

            CreateMap<OwnerViewModel, Owner>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id != Guid.Empty ? x.Id : Guid.NewGuid()));
            CreateMap<Owner, OwnerViewModel>();
        }
    }
}
