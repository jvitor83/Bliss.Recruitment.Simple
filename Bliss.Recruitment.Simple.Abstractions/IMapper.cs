using System;
using System.Diagnostics;

namespace Bliss.Recruitment.Simple.Abstractions
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
