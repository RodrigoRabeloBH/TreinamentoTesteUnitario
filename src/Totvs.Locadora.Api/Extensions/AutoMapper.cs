using AutoMapper;
using Totvs.Locadora.Api.ViewModels;
using Totvs.Locadora.Core.Models;

namespace Totvs.Locadora.Api.Extensions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Filme, FilmeViewModel>()
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento.ToString("dd/MM/yyyy")))
                .ReverseMap();
        }
    }
}
