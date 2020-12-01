using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Models.Mappers
{
    public class CoreProfile : Profile
    {
        public CoreProfile()
        {
            CreateMap<Core.Models.Input.Question, Recruitment.Simple.Models.Entities.Question>()
                .ForMember(dest => dest.PublishedAt, (map) => map.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Choices, (map) => map.MapFrom(src => src.Choices))
                ;
            CreateMap<string, Bliss.Recruitment.Simple.Models.Entities.Choice>()
                .ConstructUsing(r => new Simple.Models.Entities.Choice()
                {
                    Description = r,
                    Vote = 0,
                });

            CreateMap<Recruitment.Simple.Models.Entities.Question, Recruitment.Simple.Core.Models.Output.Question>()
                .ForMember(dest => dest.Choices, (map) => map.MapFrom(src => src.Choices))
                ;
            CreateMap<Recruitment.Simple.Models.Entities.Choice, Recruitment.Simple.Core.Models.Output.Choice>();


        }
    }
}
