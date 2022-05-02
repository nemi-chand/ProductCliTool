using ProductCli.Core.Interfaces;
using ProductCli.Implementation.Services;

namespace ProductCli.Implementation
{
    public class FileReaderFactory : IFileReaderFactory
    {
        public IFileReader GetFileReader(string fileName)
        {
            switch (fileName)
            {
                case ".json":
                    return new JsonFileReader();
                case ".yaml":
                    return new YamlFileReader();
                default:
                    break;
            }

            return null;
        }
    }
}
