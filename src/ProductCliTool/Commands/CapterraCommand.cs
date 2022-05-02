using System.CommandLine;

namespace ProductCliTool.Commands
{
    public class CapterraCommand : Command
    {
        public CapterraCommand() : base(name: "capterra", "import products from capterra.")
        {
            this.AddArgument(new Argument<string>("feed-source", "Please provide the feed source file"));
        }
    }
}
