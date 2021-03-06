using Newtonsoft.Json;
using ProductCli.Core.Interfaces;
using ProductCli.Core.Models;
using ProductCli.Implementation.Converters;

namespace ProductCli.Implementation.Capterra
{
    public class CapterraImporter : IProductImporter
    {
        private readonly IProductService _productService;
        private readonly IFileReaderFactory _readerFactory;

        public CapterraImporter(IProductService productService, IFileReaderFactory readerFactory)
        {
            _productService = productService;
            _readerFactory = readerFactory;
        }

        public IEnumerable<Product> ImportProducts(string source)
        {
            FileInfo fileInfo = new FileInfo(source);
            var fileReader = _readerFactory.GetFileReader(fileInfo.Extension);
            string jsonData = fileReader.ReadContent(source);
            var productList = JsonConvert.DeserializeObject<List<CapterraModel>>(jsonData);
            var products = productList.Select(item => item.ToProduct());
            _productService.BulkInsert(products);
            return products;
        }
    }
}
