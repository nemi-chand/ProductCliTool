using ProductCli.Core.Models;

namespace ProductCli.Implementation.Providers
{
    public class InMomeryProductDataProvider : IProductDataProvider
    {
        private static List<Product> _products = new List<Product>();

        public void BulkInsert(IEnumerable<Product> products)
        {
            _products.AddRange(products);
        }

        public void Delete(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                _products.Remove(product);
        }

        public Product Get(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Insert(Product product)
        {
            _products.Add(product);
        }
    }
}
