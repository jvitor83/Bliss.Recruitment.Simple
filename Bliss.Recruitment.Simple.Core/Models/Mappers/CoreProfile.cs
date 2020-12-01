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
            CreateMap<Core.Models.Question, Recruitment.Simple.Models.Entities.Question>().ReverseMap();
            CreateMap<Core.Models.Choice, Recruitment.Simple.Models.Entities.Choice>().ReverseMap();
        }
    }
}
