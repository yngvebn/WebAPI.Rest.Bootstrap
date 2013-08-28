using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;

namespace WebAPI.Rest.Bootstrap.Implementations.DataProviders
{
    public class ManageDataProviders : IManageDataProviders
    {
        private readonly IEnumerable<IProvideDataFor> _dataProviders;

        public ManageDataProviders(IEnumerable<IProvideDataFor> dataProviders)
        {
            _dataProviders = dataProviders;
        }
        
        public void FillModelFromProviders(Type modelType, dynamic model)
        {
            var providers = _dataProviders.Where(c => (typeof (IProvideDataFor<>).MakeGenericType(modelType)).IsInstanceOfType(c)).ToList();
            foreach(dynamic provider in providers)
            {
                provider.Fill(model);
            }
            
        }
    }
}