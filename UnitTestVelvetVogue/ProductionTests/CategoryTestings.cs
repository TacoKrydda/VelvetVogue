using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;

namespace UnitTestVelvetVogue.ProductionTests
{
    public class CategoryTestings
    {
        private readonly Mock<IGenericService<Category>> _sut;
        public CategoryTestings()
        {
            _sut = new Mock<IGenericService<Category>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new Category();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<string>(entity.Name);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new Category();

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
            var entity = new Category();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new Category();

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
            var entity = new Category();

            // Act
            entity.Id = id;

            // Assert
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new Category
            {
                Id = 1,
                Name = "Test",
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<Category>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.Name, deserializedEntity.Name);
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new Category { Id = 1, Name = "Test" };
            var createdEntity = new Category { Id = 1, Name = "Test" };
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
            var entityToDelete = new Category { Id = entityIdToDelete };
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
            var expectedEntities = new List<Category>
            {
                new Category { Id = 1, Name = "Test 1"},
                new Category { Id = 2, Name = "Test 2"}
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
            var expectedEntity = new Category { Id = entityId, Name = "Test" };
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
            var expectedUpdatedEntity = new Category { Id = entityIdToUpdate, Name = "Test Update" };
            var updatedEntity = new Category { Id = entityIdToUpdate, Name = "Test Update" };

            _sut.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _sut.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            _sut.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.Name, actualUpdatedEntity.Name);
        }
    }
}
