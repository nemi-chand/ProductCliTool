using Newtonsoft.Json;
using ProductCli.Core.Interfaces;

namespace ProductCli.Implementation.Services
{
    public class JsonFileReader : IFileReader
    {
        public string ReadContent(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(nameof(filePath));

            if (!filePath.EndsWith(".json"))
                throw new ArgumentException("import source file must be json");

            if(!File.Exists(filePath))
                throw new ArgumentException("import source file doesn't exist. Please provide valid file");

            return File.ReadAllText(filePath);
        }
    }
}
