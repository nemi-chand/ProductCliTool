using Newtonsoft.Json;

namespace ProductCli.Core.Models
{
    public class Product
    {
        public Guid Id => Guid.NewGuid();

        public string Title { get; set; }

        public string Twitter { get; set; }

        public List<string> Categories { get; set; }
    }
}
