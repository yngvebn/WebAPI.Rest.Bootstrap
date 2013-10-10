using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using WebAPI.Rest.Bootstrap.Core.Linking;
using WebAPI.Rest.Bootstrap.Interfaces.LinkProvider;

namespace WebAPI.Rest.Bootstrap.Implementations.LinkProviders
{
    public class PopulateLinksForModel : IPopulateLinksForModel
    {
        private readonly ILinkGenerator _linkGenerator;
        private readonly IEnumerable<IGenerateLinksFor> _linkGenerators;

        public PopulateLinksForModel(ILinkGenerator linkGenerator, IEnumerable<IGenerateLinksFor> linkGenerators)
        {
            _linkGenerator = linkGenerator;
            _linkGenerators = linkGenerators;
        }

        public void Populate(Type modelType, object model, LinkArgumentStyle linkArgumentStyle)
        {

            if (IsListOrArray(modelType))
            {
                PopulateList(modelType, model, linkArgumentStyle);
            }
            else
            {
                if (!modelType.IsSealed && model != null)
                    modelType.GetProperties().ForEach(propertyInfo => Populate(propertyInfo.PropertyType, propertyInfo.GetValue(model, null), linkArgumentStyle));

                var linkAttributes = modelType.GetCustomAttributes(typeof(LinksToAttribute), true).Cast<LinksToAttribute>();
                foreach (var linkAttribute in linkAttributes)
                {
                    IGenerateLinksFor linkGenerator = null;
                    if (linkAttribute.ResponseType != null)
                    {
                        var linkGeneratorType = typeof(IGenerateLinksFor<,>).MakeGenericType(linkAttribute.ResponseType, modelType);
                        linkGenerator = _linkGenerators.SingleOrDefault(linkGeneratorType.IsInstanceOfType);
                    }
                    if (linkGenerator != null)
                    {
                        var route = _linkGenerator.FindHttpRoute(linkAttribute.ResponseType);
                        linkGenerator.GetType().GetMethod("Generate").Invoke(linkGenerator, new object[] { linkAttribute, model, route, linkArgumentStyle });
                    }
                    else
                    {
                        MethodInfo generic = _linkGenerator.GetType().GetMethod("Generate").MakeGenericMethod(modelType);
                        if (linkAttribute.LinkType == LinkTo.Resource)
                        {
                            generic.Invoke(_linkGenerator, new object[] { linkAttribute.ResponseType, linkAttribute.Name, model, linkArgumentStyle });
                        }
                        else
                        {
                            generic.Invoke(_linkGenerator, new object[] { modelType, linkAttribute.LinkType.ToString(), model, linkArgumentStyle });
                        }
                    }

                }
            }
        }

        private void PopulateList(Type type, dynamic model, LinkArgumentStyle linkArgumentStyle)
        {
            if (model == null) return;

            if (type.BaseType != null && IsListOrArray(type.BaseType))
            {
                type = type.BaseType;
            }

            Type listType = type.IsArray ? type.GetElementType() : type.GetGenericArguments()[0];
            foreach (object item in model)
            {
                Populate(listType, item, linkArgumentStyle);
            }


        }

        private bool IsListOrArray(Type type)
        {
            return (type.IsArray || (type.GetInterface(typeof(ICollection<>).FullName) != null));

        }
    }
}