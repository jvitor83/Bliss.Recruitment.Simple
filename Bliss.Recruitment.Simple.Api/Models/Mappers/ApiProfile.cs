using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Models.Mappers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Response.Question, Core.Models.Question>();
            CreateMap<Response.Choice, Core.Models.Choice>();
        }
    }
}
