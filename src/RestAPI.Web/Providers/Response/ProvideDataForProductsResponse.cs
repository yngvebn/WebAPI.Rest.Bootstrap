using System.Linq;
using RestAPI.Contracts;
using RestAPI.Core.DataProviders;
using RestAPI.Data;

namespace RestAPI.Web.Providers.Response
{
    public class ProvideDataForProductsResponse: IProvideDataFor<Products>
    {
        private readonly IProductRepository _productRepository;

        public ProvideDataForProductsResponse(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Fill(Products model)
        {
            model.AllProducts = _productRepository.All().ToList();
        }
    }
}