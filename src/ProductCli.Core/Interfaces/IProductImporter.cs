using ProductCli.Core.Models;

namespace ProductCli.Core.Interfaces
{
    public interface IProductImporter
    {
        IEnumerable<Product> ImportProducts(string source);
    }
}
