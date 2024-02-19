using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace UnitTestVelvetVogue
{
    public class ColorTestings
    {
        private readonly Mock<IGenericService<Color>> _entityServiceMock;
        public ColorTestings()
        {
            _entityServiceMock = new Mock<IGenericService<Color>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new Color();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<string>(entity.Name);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new Color();

            // Act
            entity.Id = 1;
            entity.Name = "test";

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal("test", entity.Name);
        }

        [Fact]
        public void Entity_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange
            var entity = new Color();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new Color();

            // Assert
            Assert.Equal(0, entity.Id);
            Assert.Equal(string.Empty, entity.Name);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Entity_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var entity = new Color();

            // Act
            entity.Id = id;

            // Assert
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new Color
            {
                Id = 1,
                Name = "Test",
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<Color>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.Name, deserializedEntity.Name);
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new Color { Id = 1, Name = "Test" };
            var createdEntity = new Color { Id = 1, Name = "Test" };
            _entityServiceMock.Setup(service => service.CreateAsync(expectedEntity))
                               .ReturnsAsync(createdEntity);

            var entityService = _entityServiceMock.Object;

            // Act
            var actualEntity = await entityService.CreateAsync(expectedEntity);

            // Assert
            _entityServiceMock.Verify(service => service.CreateAsync(expectedEntity), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
        }

        [Fact]
        public async Task DeleteEntity_ExistingEntity_ReturnsDeletedEntity()
        {
            // Arrange
            var entityIdToDelete = 1;
            var entityToDelete = new Color { Id = entityIdToDelete };
            _entityServiceMock.Setup(service => service.DeleteAsync(entityIdToDelete))
                               .ReturnsAsync(entityToDelete);

            var entityService = _entityServiceMock.Object;

            // Act
            var deletedEntity = await entityService.DeleteAsync(entityIdToDelete);

            // Assert
            _entityServiceMock.Verify(service => service.DeleteAsync(entityIdToDelete), Times.Once);
            Assert.Equal(entityIdToDelete, deletedEntity.Id);
        }

        [Fact]
        public async Task GetAllEntities_ReturnsAllEntities()
        {
            // Arrange
            var expectedEntities = new List<Color>
            {
                new Color { Id = 1, Name = "Test 1"},
                new Color { Id = 2, Name = "Test 2"}
            };
            _entityServiceMock.Setup(service => service.GetAllAsync())
                               .ReturnsAsync(expectedEntities);

            var entityService = _entityServiceMock.Object;

            // Act
            var actualEntity = await entityService.GetAllAsync();

            // Assert
            _entityServiceMock.Verify(service => service.GetAllAsync(), Times.Once);
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
            var expectedEntity = new Color { Id = entityId, Name = "Test" };
            _entityServiceMock.Setup(service => service.GetByIdAsync(entityId))
                               .ReturnsAsync(expectedEntity);

            var entityService = _entityServiceMock.Object;

            // Act
            var actualEntity = await entityService.GetByIdAsync(entityId);

            // Assert
            _entityServiceMock.Verify(service => service.GetByIdAsync(entityId), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
        }

        [Fact]
        public async Task UpdateEntity_ValidEntity_ReturnsUpdatedEntity()
        {
            // Arrange
            var entityIdToUpdate = 1;
            var expectedUpdatedEntity = new Color { Id = entityIdToUpdate, Name = "Test Update" };
            var updatedEntity = new Color { Id = entityIdToUpdate, Name = "Test Update" };

            _entityServiceMock.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _entityServiceMock.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            // Assert
            _entityServiceMock.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.Name, actualUpdatedEntity.Name);
        }
    }
}
