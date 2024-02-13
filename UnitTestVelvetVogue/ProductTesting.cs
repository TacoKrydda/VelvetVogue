using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopClassLibrary.Models.Production;

namespace UnitTestVelvetVogue
{
    public class ProductTesting
    {
        [Fact]
        public void Product_Properties_Have_Correct_Types()
        {
            // Arrange
            var product = new Product();
            // Act

            // Assert
            Assert.IsType<int>(product.Id);
            Assert.IsType<string>(product.ProductName);
            Assert.IsType<int>(product.BrandId);
            Assert.IsType<int>(product.CategoryId);
            Assert.IsType<int>(product.ColorId);
            Assert.IsType<int>(product.SizeId);
            Assert.IsType<decimal>(product.Price);
        }

        [Fact]
        public void Product_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var product = new Product();

            // Act
            product.Id = 1;
            product.ProductName = "Test Product";
            product.BrandId = 1;
            product.CategoryId = 1;
            product.ColorId = 1;
            product.SizeId = 1;
            product.Price = 10.99m;

            // Assert
            Assert.Equal(1, product.Id);
            Assert.Equal("Test Product", product.ProductName);
            Assert.Equal(1, product.BrandId);
            Assert.Equal(1, product.CategoryId);
            Assert.Equal(1, product.ColorId);
            Assert.Equal(1, product.SizeId);
            Assert.Equal(10.99m, product.Price);
        }

        [Fact]
        public void Product_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange & Act
            var product = new Product();

            // Assert
            Assert.NotNull(product);
        }

        [Fact]
        public void Product_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var product = new Product();

            // Assert
            Assert.Equal(0, product.Id);
            Assert.Equal(string.Empty, product.ProductName);
            Assert.Equal(0, product.BrandId);
            Assert.Equal(0, product.CategoryId);
            Assert.Equal(0, product.ColorId);
            Assert.Equal(0, product.SizeId);
            Assert.Equal(0m, product.Price);
            Assert.NotNull(product.Stock);
        }

        [Fact]
        public void JsonIgnore_Attribute_Is_Applied()
        {
            // Arrange
            var product = new Product();

            // Act
            var serializedProduct = JsonConvert.SerializeObject(product);
            var deserializedProduct = JsonConvert.DeserializeObject<Product>(serializedProduct);

            // Assert
            Assert.Null(deserializedProduct.Brand);
            Assert.Null(deserializedProduct.Category);
            Assert.Null(deserializedProduct.Color);
            Assert.Null(deserializedProduct.Size);
        }
    }
}
