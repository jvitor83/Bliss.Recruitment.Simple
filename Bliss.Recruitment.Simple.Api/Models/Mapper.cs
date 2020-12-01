using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bliss.Recruitment.Simple.Api.Models
{
    public class Mapper : Abstractions.IMapper
    {
        public readonly IMapper _autoMapper;
        public Mapper(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
        public TDestination Map<TDestination>(object source)
        {
            return _autoMapper.Map<TDestination>(source);
        }
    }
}
