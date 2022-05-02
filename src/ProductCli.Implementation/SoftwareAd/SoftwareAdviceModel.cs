namespace ProductCli.Implementation.SoftwareAd
{
    internal class SoftwareAdviceModel
    {
        public IList<SoftwareAdvice> Products { get; set; }
    }

    internal class SoftwareAdvice
    {
        public string Title { get; set; }

        public string Twitter { get; set; }
        public List<string> Categories { get; set; }
    }
}
