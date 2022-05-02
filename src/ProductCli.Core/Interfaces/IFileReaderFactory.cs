namespace ProductCli.Core.Interfaces
{
    public interface IFileReaderFactory
    {
        IFileReader GetFileReader(string fileName);
    }
}
