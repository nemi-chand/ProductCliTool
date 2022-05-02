using ProductCli.Core.Models;

namespace ProductCli.Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product Get(Guid id);

        void BulkInsert(IEnumerable<Product> products);

        void Insert(Product product);

        void Delete(Guid id);
    }
}
