using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;

namespace RestAPI.Core.LinkProviders
{
    public class ManageLinkProviders : IManageLinkProviders
    {
        private readonly IGenerateLinkTo _generateLinkTo;
        private readonly IEnumerable<IGenerateLinksFor> _linkGenerators;

        public ManageLinkProviders(IGenerateLinkTo generateLinkTo, IEnumerable<IGenerateLinksFor> linkGenerators)
        {
            _generateLinkTo = generateLinkTo;
            _linkGenerators = linkGenerators;
        }

        public void PopulateLinksForModel(Type modelType, object model)
        {

            if (IsListOrArray(modelType))
            {
                PopulateList(modelType, model);
            }
            else
            {
                if (!modelType.IsSealed && model != null)
                    modelType.GetProperties().ForEach(propertyInfo => PopulateLinksForModel(propertyInfo.PropertyType, propertyInfo.GetValue(model, null)));

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
                        var route = _generateLinkTo.FindHttpRoute(linkAttribute.ResponseType);
                        linkGenerator.GetType().GetMethod("Generate").Invoke(linkGenerator, new object[] { linkAttribute, model, route });
                    }
                    else
                    {
                        MethodInfo generic = _generateLinkTo.GetType().GetMethod("Generate").MakeGenericMethod(modelType);
                        if (linkAttribute.LinkType == LinkTo.Resource)
                        {
                            generic.Invoke(_generateLinkTo, new object[] { linkAttribute.ResponseType, linkAttribute.Name, model });
                        }
                        else
                        {
                            generic.Invoke(_generateLinkTo, new object[] { modelType, linkAttribute.LinkType.ToString(), model });
                        }
                    }

                }
            }
        }

        private void PopulateList(Type type, dynamic model)
        {
            if (model == null) return;

            if (type.BaseType != null && IsListOrArray(type.BaseType))
            {
                type = type.BaseType;
            }

            Type listType = type.IsArray ? type.GetElementType() : type.GetGenericArguments()[0];
            foreach (object item in model)
            {
                PopulateLinksForModel(listType, item);
            }


        }

        private bool IsListOrArray(Type type)
        {
            return (type.IsArray || (type.GetInterface(typeof(ICollection<>).FullName) != null));

        }
    }
}