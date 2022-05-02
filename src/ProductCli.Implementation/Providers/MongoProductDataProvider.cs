using ProductCli.Core.Models;

namespace ProductCli.Implementation.Providers
{
    /*
     * This is a dummy file for future reference purpose only
     */
    public class MongoProductDataProvider : IProductDataProvider
    {
        public void BulkInsert(IEnumerable<Product> products)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            //TODO
            throw new NotImplementedException();
        }

        public Product Get(Guid id)
        {
            //TODO
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            //TODO
            throw new NotImplementedException();
        }

        public void Insert(Product product)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
