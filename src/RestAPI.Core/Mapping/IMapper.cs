using System;

namespace RestAPI.Core.Mapping
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source);
        void Map<TSource, TDestination>(TSource source, TDestination destination);
        object Map(object source, Type sourceType, Type destinationType);
    }
}