using ProductCli.Core.Models;
using ProductCli.Implementation.Capterra;
using ProductCli.Implementation.SoftwareAd;

namespace ProductCli.Implementation.Converters
{
    internal static class ProductConverter
    {
        public static Product ToProduct(this CapterraModel model)
        {
            return new Product()
            {
               Title = model.Name,
               Twitter = model.Twitter,
               Categories = model.Tags.Split(',').ToList(),
            };
        }

        public static Product ToProduct(this SoftwareAdvice model)
        {
            return new Product()
            {
                Title = model.Title,
                Twitter = model.Twitter,
                Categories = model.Categories,
            };
        }
    }
}
