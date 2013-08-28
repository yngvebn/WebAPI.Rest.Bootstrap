using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using AutoMapper;

namespace RestAPI.Core.Mapping
{
    public class OurMapper : IMapper
    {
        private readonly IList<IMappingConfiguration> _configurations;

        public OurMapper(IList<IMappingConfiguration> configurations)
        {
            _configurations = configurations;

            _configurations.ForEach(configuration => configuration.Configure());
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Mapper.Map(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, Type destinationType)
        {
            return Map(source, source.GetType(), destinationType);
        }

        public TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}