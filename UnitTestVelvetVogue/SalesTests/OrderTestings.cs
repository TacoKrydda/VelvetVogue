using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;

namespace UnitTestVelvetVogue.SalesTests
{
    public class OrderTestings
    {
        private readonly Mock<IGenericService<Order>> _sut;
        private List<CartItem> _cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = 1,
                    ProductId = 1,
                    Quantity = 1,
                },
                new CartItem
                {
                    Id = 2,
                    ProductId = 2,
                    Quantity = 1,
                }
            };

        public OrderTestings()
        {
            _sut = new Mock<IGenericService<Order>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new Order();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<int>(entity.CustomerId);
            Assert.IsType<string>(entity.OrderStatus);
            Assert.True(entity.OrderDate == null || entity.OrderDate is DateTime);
            Assert.True(entity.ShippedDate == null || entity.ShippedDate is DateTime);
            Assert.IsType<List<CartItem>>(entity.CartItems);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new Order();
            DateTime expectedDate = new DateTime(2024, 2, 13, 12, 0, 0); // 2024-02-13 12:00:00

            // Act
            entity.Id = 1;
            entity.CustomerId = 1;
            entity.OrderStatus = "Pending";
            entity.OrderDate = expectedDate;
            entity.ShippedDate = expectedDate;
            entity.TotalPrice = 10.99m;
            entity.CartItems = _cartItems;

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal(1, entity.CustomerId);
            Assert.Equal("Pending", entity.OrderStatus);
            Assert.Equal(expectedDate, entity.OrderDate);
            Assert.Equal(expectedDate, entity.ShippedDate);
            Assert.Equal(10.99m, entity.TotalPrice);
            Assert.Equal(_cartItems, entity.CartItems);
        }

        [Fact]
        public void Entity_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange
            var entity = new Order();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new Order();
            var expectedOrderDate = DateTime.Today;

            // Assert
            Assert.Equal(0, entity.Id);
            Assert.Equal(0, entity.CustomerId);
            Assert.Equal("", entity.OrderStatus);
            Assert.Equal(DateTime.MinValue, entity.OrderDate);
            Assert.Null(entity.ShippedDate);
            Assert.Equal(0,entity.TotalPrice);
            Assert.Empty(entity.CartItems);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Entity_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var entity = new Order();

            // Act
            entity.Id = id;
            entity.CustomerId = id;

            // Assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(id, entity.CustomerId);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new Order
            {
                Id = 1,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<Order>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.CustomerId, deserializedEntity.CustomerId);
            Assert.Equal(originalEntity.OrderStatus, deserializedEntity.OrderStatus);
            Assert.Equal(originalEntity.OrderDate, deserializedEntity.OrderDate);
            Assert.Equal(originalEntity.ShippedDate, deserializedEntity.ShippedDate);

            // Assert for CartItems
            Assert.Equal(originalEntity.CartItems.Count, deserializedEntity.CartItems.Count);

            // Check each item in the list
            for (int i = 0; i < originalEntity.CartItems.Count; i++)
            {
                Assert.Equal(originalEntity.CartItems[i].Id, deserializedEntity.CartItems[i].Id);
                Assert.Equal(originalEntity.CartItems[i].ProductId, deserializedEntity.CartItems[i].ProductId);
                Assert.Equal(originalEntity.CartItems[i].Quantity, deserializedEntity.CartItems[i].Quantity);
            }
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new Order
            {
                Id = 1,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };

            var createdEntity = new Order
            {
                Id = 1,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };

            _sut.Setup(service => service.CreateAsync(expectedEntity))
                               .ReturnsAsync(createdEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.CreateAsync(expectedEntity);

            // Assert
            _sut.Verify(service => service.CreateAsync(expectedEntity), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
            Assert.Equal(expectedEntity.CustomerId, actualEntity.CustomerId);
            Assert.Equal(expectedEntity.OrderStatus, actualEntity.OrderStatus);
            Assert.Equal(expectedEntity.ShippedDate, actualEntity.ShippedDate);
            Assert.Equal(expectedEntity.TotalPrice, actualEntity.TotalPrice);

            // Assert for CartItems
            Assert.Equal(expectedEntity.CartItems.Count, actualEntity.CartItems.Count);

            // Check each item in the list
            for (int i = 0; i < expectedEntity.CartItems.Count; i++)
            {
                Assert.Equal(expectedEntity.CartItems[i].Id, actualEntity.CartItems[i].Id);
                Assert.Equal(expectedEntity.CartItems[i].ProductId, actualEntity.CartItems[i].ProductId);
                Assert.Equal(expectedEntity.CartItems[i].Quantity, actualEntity.CartItems[i].Quantity);
            }

        }

        [Fact]
        public async Task DeleteEntity_ExistingEntity_ReturnsDeletedEntity()
        {
            // Arrange
            var entityIdToDelete = 1;
            var entityToDelete = new Order { Id = entityIdToDelete };
            _sut.Setup(service => service.DeleteAsync(entityIdToDelete))
                               .ReturnsAsync(entityToDelete);

            var entityService = _sut.Object;

            // Act
            var deletedEntity = await entityService.DeleteAsync(entityIdToDelete);

            // Assert
            _sut.Verify(service => service.DeleteAsync(entityIdToDelete), Times.Once);
            Assert.Equal(entityIdToDelete, deletedEntity.Id);
        }

        [Fact]
        public async Task GetAllEntities_ReturnsAllEntities()
        {
            // Arrange
            var expectedEntities = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderStatus = "Shipped",
                    OrderDate = DateTime.Today,
                    ShippedDate = DateTime.Today,
                    TotalPrice = 1,
                    CartItems = _cartItems
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    OrderStatus = "Shipped",
                    OrderDate = DateTime.Today,
                    ShippedDate = DateTime.Today,
                    TotalPrice = 2,
                    CartItems = _cartItems
                }
            };
            _sut.Setup(service => service.GetAllAsync())
                               .ReturnsAsync(expectedEntities);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.GetAllAsync();

            // Assert
            _sut.Verify(service => service.GetAllAsync(), Times.Once);
            Assert.Equal(expectedEntities.Count, actualEntity.Count());
            foreach (var expectedEntity in expectedEntities)
            {
                Assert.Contains(expectedEntity, actualEntity);
            }
        }

        [Fact]
        public async Task GetEntityById_ExistingId_ReturnsCorrectEntity()
        {
            // Arrange
            var entityId = 1;
            var expectedEntity = new Order
            {
                Id = entityId,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };
            _sut.Setup(service => service.GetByIdAsync(entityId))
                               .ReturnsAsync(expectedEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.GetByIdAsync(entityId);

            // Assert
            _sut.Verify(service => service.GetByIdAsync(entityId), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
            Assert.Equal(expectedEntity.CustomerId, actualEntity.CustomerId);
            Assert.Equal(expectedEntity.OrderStatus, actualEntity.OrderStatus);
            Assert.Equal(expectedEntity.ShippedDate, actualEntity.ShippedDate);
            Assert.Equal(expectedEntity.TotalPrice, actualEntity.TotalPrice);

            // Assert for CartItems
            Assert.Equal(expectedEntity.CartItems.Count, actualEntity.CartItems.Count);

            // Check each item in the list
            for (int i = 0; i < expectedEntity.CartItems.Count; i++)
            {
                Assert.Equal(expectedEntity.CartItems[i].Id, actualEntity.CartItems[i].Id);
                Assert.Equal(expectedEntity.CartItems[i].ProductId, actualEntity.CartItems[i].ProductId);
                Assert.Equal(expectedEntity.CartItems[i].Quantity, actualEntity.CartItems[i].Quantity);
            }

        }

        [Fact]
        public async Task UpdateEntity_ValidEntity_ReturnsUpdatedEntity()
        {
            // Arrange
            var entityIdToUpdate = 1;
            var expectedUpdatedEntity = new Order
            {
                Id = entityIdToUpdate,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };
            var updatedEntity = new Order
            {
                Id = entityIdToUpdate,
                CustomerId = 1,
                OrderStatus = "Shipped",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today,
                TotalPrice = 1,
                CartItems = _cartItems
            };

            _sut.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _sut.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            _sut.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.CustomerId, actualUpdatedEntity.CustomerId);
            Assert.Equal(expectedUpdatedEntity.OrderStatus, actualUpdatedEntity.OrderStatus);
            Assert.Equal(expectedUpdatedEntity.OrderDate, actualUpdatedEntity.OrderDate);

            // Assert for CartItems
            Assert.Equal(expectedUpdatedEntity.CartItems.Count, actualUpdatedEntity.CartItems.Count);

            // Check each item in the list
            for (int i = 0; i < expectedUpdatedEntity.CartItems.Count; i++)
            {
                Assert.Equal(expectedUpdatedEntity.CartItems[i].Id, actualUpdatedEntity.CartItems[i].Id);
                Assert.Equal(expectedUpdatedEntity.CartItems[i].ProductId, actualUpdatedEntity.CartItems[i].ProductId);
                Assert.Equal(expectedUpdatedEntity.CartItems[i].Quantity, actualUpdatedEntity.CartItems[i].Quantity);
            }

        }

    }
}
