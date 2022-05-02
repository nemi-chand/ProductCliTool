using Newtonsoft.Json;
using ProductCli.Core.Interfaces;
using YamlDotNet.Serialization;

namespace ProductCli.Implementation.Services
{
    public class YamlFileReader : IFileReader
    {
        public string ReadContent(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(nameof(filePath));

            if (!filePath.EndsWith(".yaml"))
                throw new ArgumentException("import source file must be yaml");

            if (!File.Exists(filePath))
                throw new ArgumentException("import source file doesn't exist. Please provide valid file");

            StreamReader yamlStreamReader = new StreamReader(filePath);
            var yamlData = new Deserializer().Deserialize(yamlStreamReader);
            var writer = new StringWriter();
            new JsonSerializer().Serialize(writer, yamlData);
            return writer.ToString();
        }
    }
}
