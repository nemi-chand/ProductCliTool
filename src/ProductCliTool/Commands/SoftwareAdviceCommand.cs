using System.CommandLine;

namespace ProductCliTool.Commands
{
    public class SoftwareAdviceCommand : Command
    { 
        public SoftwareAdviceCommand() : base(name: "softwareadvice", "import products from software advice source.")
        {
            this.AddArgument(new Argument<string>("feed-source", "Please provide the feed source file"));
        }
    }
}
