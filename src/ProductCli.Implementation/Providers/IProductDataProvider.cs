using ProductCli.Core.Models;

namespace ProductCli.Implementation.Providers
{
    public interface IProductDataProvider
    {
        IEnumerable<Product> GetAll();

        Product Get(Guid id);

        void BulkInsert(IEnumerable<Product> products);

        void Insert(Product product);

        void Delete(Guid id);
    }
}
