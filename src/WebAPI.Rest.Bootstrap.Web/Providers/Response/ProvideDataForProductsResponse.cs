using System.Linq;
using WebAPI.Rest.Bootstrap.Contracts;
using WebAPI.Rest.Bootstrap.Data;
using WebAPI.Rest.Bootstrap.Interfaces.DataProvider;

namespace WebAPI.Rest.Bootstrap.Web.Providers.Response
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