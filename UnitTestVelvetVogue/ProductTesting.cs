using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Services.Production;
using WebbShopClassLibrary.Services;
using WebbShopClassLibrary.Context;
using Microsoft.EntityFrameworkCore;

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

        [Fact]
        public void Product_Can_Set_and_Get_Associated_Brand()
        {
            // Arrange
            var product = new Product();
            var brand = new Brand { BrandName = "Test Brand" };

            // Act
            product.Brand = brand;

            // Assert
            Assert.Equal(brand, product.Brand);
        }

        [Fact]
        public void Product_Can_Set_and_Get_Associated_Category()
        {
            // Arrange
            var product = new Product();
            var category = new Category { CategoryName = "Test Category" };

            // Act
            product.Category = category;

            // Assert
            Assert.Equal(category, product.Category);
        }

        [Fact]
        public void Product_Can_Set_and_Get_Associated_Color()
        {
            // Arrange
            var product = new Product();
            var color = new Color { ColorName = "Test Color" };

            // Act
            product.Color = color;

            // Assert
            Assert.Equal(color, product.Color);
        }

        [Fact]
        public void Product_Can_Set_and_Get_Associated_Size()
        {
            // Arrange
            var product = new Product();
            var size = new Size { SizeName = "Test Size" };

            // Act
            product.Size = size;

            // Assert
            Assert.Equal(size, product.Size);
        }

        [Fact]
        public void Product_Can_Set_and_Get_Associated_Stock()
        {
            // Arrange
            var product = new Product();
            var stock = new Stock { Quantity = 10 };

            // Act
            product.Stock = stock;

            // Assert
            Assert.Equal(stock, product.Stock);
        }

        [Theory]
        [InlineData(10.99)]
        [InlineData(20.49)]
        [InlineData(100.0)]
        public void Product_Price_Can_Be_Set_and_Get(decimal price)
        {
            // Arrange
            var product = new Product();

            // Act
            product.Price = price;

            // Assert
            Assert.Equal(price, product.Price);
        }

        [Theory]
        [InlineData(-10.99)]
        public void Product_Price_Cannot_Be_Negative(decimal price)
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Price = price);
        }

        [Fact]
        public void Product_Id_Can_Be_Set_and_Get()
        {
            // Arrange
            var product = new Product();
            var expectedId = 1;

            // Act
            product.Id = expectedId;

            // Assert
            Assert.Equal(expectedId, product.Id);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Product_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var product = new Product();

            // Act
            product.Id = id;

            // Assert
            Assert.Equal(id, product.Id);
        }

        [Theory]
        [InlineData(0.01)]
        [InlineData(999999.99)]
        public void Product_Price_Can_Be_Set_and_Get_Boundary(decimal price)
        {
            // Arrange
            var product = new Product();

            // Act
            product.Price = price;

            // Assert
            Assert.Equal(price, product.Price);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(1000)]
        public void Stock_Quantity_Can_Be_Set_and_Get_Boundary(int quantity)
        {
            // Arrange
            var stock = new Stock();

            // Act
            stock.Quantity = quantity;

            // Assert
            Assert.Equal(quantity, stock.Quantity);
        }

        [Fact]
        public void Product_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalProduct = new Product
            {
                Id = 1,
                ProductName = "Test Product",
                BrandId = 1,
                CategoryId = 1,
                ColorId = 1,
                SizeId = 1,
                Price = 10.99m
            };

            // Act
            var serializedProduct = JsonConvert.SerializeObject(originalProduct);
            var deserializedProduct = JsonConvert.DeserializeObject<Product>(serializedProduct);

            // Assert
            Assert.Equal(originalProduct.Id, deserializedProduct.Id);
            Assert.Equal(originalProduct.ProductName, deserializedProduct.ProductName);
            Assert.Equal(originalProduct.BrandId, deserializedProduct.BrandId);
            Assert.Equal(originalProduct.CategoryId, deserializedProduct.CategoryId);
            Assert.Equal(originalProduct.ColorId, deserializedProduct.ColorId);
            Assert.Equal(originalProduct.SizeId, deserializedProduct.SizeId);
            Assert.Equal(originalProduct.Price, deserializedProduct.Price);
        }

        
    }
}
