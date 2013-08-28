using System.Collections.Generic;
using WebAPI.Rest.Bootstrap.Contracts;

namespace WebAPI.Rest.Bootstrap.Data
{
    public interface IProductRepository
    {
        IList<Product> All();
        Product Find(int productSku);
    }
}