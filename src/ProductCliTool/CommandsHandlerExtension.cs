using Microsoft.Extensions.Hosting;
using ProductCliTool.Commands;
using ProductCliTool.Commands.Handlers;
using System.CommandLine.Hosting;

namespace ProductCliTool
{
    public static class CommandsHandlerExtension
    {
        public static IHostBuilder RegisterCliCommands(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseCommandHandler<CapterraCommand, CapterraCommandHandler>()
            .UseCommandHandler<SoftwareAdviceCommand, SoftwareAdviceCommandHandler>();
            return hostBuilder;
        }
    }
}
