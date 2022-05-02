using Microsoft.Extensions.Hosting;
using ProductCliTool;
using ProductCliTool.Commands;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;

var runner = BuildCommandLine()
    .UseHost(_ => Host.CreateDefaultBuilder(args), (builder) =>
    {
        builder.ConfigureServices((hostContext, services) =>
        {
            services.RegisterServices();            
        })
        .RegisterCliCommands();
    }).UseDefaults().Build();

return await runner.InvokeAsync(args);

static CommandLineBuilder BuildCommandLine()
{
    var root = new RootCommand();
    root.AddCommand(new CapterraCommand());
    root.AddCommand(new SoftwareAdviceCommand());
    root.Name = "import";
    root.Handler = CommandHandler.Create(() =>
    {
        root.Invoke("-h");
    });

    return new CommandLineBuilder(root);
}
