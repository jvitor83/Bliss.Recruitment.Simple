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
            CreateMap<Core.Models.Output.Question, Response.Question>()
                .ForMember(dst => dst.QuestionId, map => map.MapFrom(src => src.QuestionId))
                .ForMember(dst => dst.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dst => dst.ImageUrl, map => map.MapFrom(src => src.ImageUrl))
                .ForMember(dst => dst.ThumbUrl, map => map.MapFrom(src => src.ThumbUrl))
                .ForMember(dst => dst.Choices, map => map.MapFrom(src => src.Choices))
                ;

            CreateMap<Core.Models.Output.Choice, Response.Choice>()
                .ForMember(dst => dst.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dst => dst.Vote, map => map.MapFrom(src => src.Vote))
                ;


            CreateMap<Request.RegisterQuestionRequestModel, Core.Models.Input.Question>()
                .ForMember(dst => dst.QuestionId, map => map.MapFrom(src => src.QuestionId))
                .ForMember(dst => dst.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dst => dst.ImageUrl, map => map.MapFrom(src => src.ImageUrl))
                .ForMember(dst => dst.ThumbUrl, map => map.MapFrom(src => src.ThumbUrl))
                .ForMember(dst => dst.Choices, map => map.MapFrom(src => src.Choices))
                ;
        }
    }
}
