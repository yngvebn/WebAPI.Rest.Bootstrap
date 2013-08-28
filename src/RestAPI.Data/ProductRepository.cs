using System.Collections.Generic;
using System.Linq;
using RestAPI.Contracts;

namespace RestAPI.Data
{
    public interface IProductRepository
    {
        IList<Product> All();
        Product Find(int productSku);
    }

    public class ProductRepository : IProductRepository
    {
        public IList<Product> All()
        {
            return new List<Product>()
                {
                    new Product(){ Color = "Black", Manufacturer = "Logitech", Name = "Harmony One", Sku = 1, ListPrice = 99},
                    new Product(){ Color = "Gray", Manufacturer = "Leap", Name = "Leap Motion", Sku = 2, ListPrice = 80},
                    new Product(){ Color = "White", Manufacturer = "Avent", Name = "Babycall", Sku = 3, ListPrice = 119},
                    new Product(){ Color = "Black", Manufacturer = "Yamaha", Name = "P120", Sku = 4, ListPrice = 1100},
                    new Product(){ Color = "Sunburst", Manufacturer = "Fender", Name = "Stratocaster", Sku = 5, ListPrice = 2999},
                    new Product(){ Color = "Chocolate Brown", Manufacturer = "Nestlé", Name = "Lion bar", Sku = 6, ListPrice = 2},
                    new Product(){ Color = "White", Manufacturer = "Apple", Name = "iPad 3", Sku = 7, ListPrice = 899}
                };
        }

        public Product Find(int productSku)
        {
            return All().FirstOrDefault(product => product.Sku == productSku);
        }
    }
}