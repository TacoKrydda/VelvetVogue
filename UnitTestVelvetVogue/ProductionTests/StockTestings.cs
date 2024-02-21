using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace UnitTestVelvetVogue.ProductionTests
{
    public class StockTestings
    {
        private readonly Mock<IGenericService<Stock>> _sut;

        public StockTestings()
        {
            _sut = new Mock<IGenericService<Stock>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new Stock();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<int>(entity.ProductId);
            Assert.IsType<int>(entity.Quantity);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new Stock();

            // Act
            entity.Id = 1;
            entity.ProductId = 1;
            entity.Quantity = 1;

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal(1, entity.ProductId);
            Assert.Equal(1, entity.Quantity);
        }

        [Fact]
        public void Entity_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange
            var entity = new Stock();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new Stock();

            // Assert
            Assert.Equal(0, entity.Id);
            Assert.Equal(0, entity.ProductId);
            Assert.Equal(0, entity.Quantity);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Entity_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var entity = new Stock();

            // Act
            entity.Id = id;
            entity.ProductId = id;
            entity.Quantity = id;

            // Assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(id, entity.ProductId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999)]
        public void Product_Price_Can_Be_Set_and_Get_Boundary(int quantity)
        {
            // Arrange
            var entity = new Stock();

            // Act
            entity.Quantity = quantity;

            // Assert
            Assert.Equal(quantity, entity.Quantity);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new Stock
            {
                Id = 1,
                ProductId = 1,
                Quantity = 1,
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<Stock>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.ProductId, deserializedEntity.ProductId);
            Assert.Equal(originalEntity.Quantity, deserializedEntity.Quantity);
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new Stock { Id = 1, ProductId = 1, Quantity = 1 };
            var createdEntity = new Stock { Id = 1, ProductId = 1, Quantity = 1 };
            _sut.Setup(service => service.CreateAsync(expectedEntity))
                               .ReturnsAsync(createdEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.CreateAsync(expectedEntity);

            // Assert
            _sut.Verify(service => service.CreateAsync(expectedEntity), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
        }

        [Fact]
        public async Task DeleteEntity_ExistingEntity_ReturnsDeletedEntity()
        {
            // Arrange
            var entityIdToDelete = 1;
            var entityToDelete = new Stock { Id = entityIdToDelete };
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
            var expectedEntities = new List<Stock>
            {
                new Stock { Id = 1, ProductId = 1, Quantity = 1},
                new Stock { Id = 2, ProductId = 2, Quantity = 2}
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
            var expectedEntity = new Stock { Id = 1, ProductId = 1, Quantity = 1 };
            _sut.Setup(service => service.GetByIdAsync(entityId))
                               .ReturnsAsync(expectedEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.GetByIdAsync(entityId);

            // Assert
            _sut.Verify(service => service.GetByIdAsync(entityId), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
        }

        [Fact]
        public async Task UpdateEntity_ValidEntity_ReturnsUpdatedEntity()
        {
            // Arrange
            var entityIdToUpdate = 1;
            var expectedUpdatedEntity = new Stock { Id = entityIdToUpdate, ProductId = 1, Quantity = 1 };
            var updatedEntity = new Stock { Id = entityIdToUpdate, ProductId = 1, Quantity = 1 };

            _sut.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _sut.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            _sut.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.ProductId, actualUpdatedEntity.ProductId);
            Assert.Equal(expectedUpdatedEntity.Quantity, actualUpdatedEntity.Quantity);
        }

    }
}
