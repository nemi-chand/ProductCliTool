using ProductCli.Core.Interfaces;
using ProductCli.Core.Models;
using ProductCli.Implementation.Providers;

namespace ProductCli.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductService(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public void BulkInsert(IEnumerable<Product> products)
        {
            _productDataProvider.BulkInsert(products);
        }

        public void Delete(Guid id)
        {
            _productDataProvider.Delete(id);
        }

        public Product Get(Guid id)
        {
            return _productDataProvider.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDataProvider.GetAll();
        }

        public void Insert(Product product)
        {
            _productDataProvider.Insert(product);
        }
    }
}
