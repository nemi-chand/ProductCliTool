using Moq;
using NUnit.Framework;
using ProductCli.Core.Models;
using ProductCli.Implementation.Providers;
using ProductCli.Implementation.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProductCli.Implementation.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {

        private Mock<IProductDataProvider> _productDataProviderMock;

        [SetUp]
        public void Setup()
        {
            _productDataProviderMock = new Mock<IProductDataProvider>();
        }

        [Test]
        public void GetAllTest()
        {
            _productDataProviderMock.Setup(x => x.GetAll()).Returns(new List<Product>() { new Product() { Title = "test", Twitter = "@test", Categories = new List<string>() { "dummy" } } });
            var service = GetService();
            var actualResult = service.GetAll();
            Assert.AreEqual(1, actualResult.Count());
            var product = actualResult.FirstOrDefault();
            Assert.AreEqual("test", product.Title);
            Assert.AreEqual("@test", product.Twitter);
            Assert.AreEqual(1, product.Categories.Count);
        }

        private ProductService GetService()
        {
            return new ProductService(_productDataProviderMock.Object);
        }
    }
}