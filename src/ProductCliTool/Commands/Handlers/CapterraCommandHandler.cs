using ProductCli.Core.Interfaces;
using System.CommandLine.Invocation;

namespace ProductCliTool.Commands.Handlers
{
    public class CapterraCommandHandler : ICommandHandler
    {
        private readonly IProductImporter _productImporter;

        public CapterraCommandHandler(Func<string, IProductImporter> productImporterFactory )
        {
            _productImporter = productImporterFactory("capterra");
        }

        public Task<int> InvokeAsync(InvocationContext context)
        {
            string file = context.ParseResult.Tokens[context.ParseResult.Tokens.Count -1].Value;
            if (!File.Exists(file))
            {
                context.Console.Out.Write($"{file} : file doesn't exist. Please provide valid file");
                return Task.FromResult(0);
            }
            var products = _productImporter.ImportProducts(file);
            foreach (var item in products)
            {
                context.Console.Out.Write($"importing: Name: {item.Title};  Categories: {string.Join(",", item.Categories)}; Twitter: {item.Twitter} \n");
            }
            return Task.FromResult(0);
        }
    }
}
