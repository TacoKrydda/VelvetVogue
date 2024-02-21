using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Models.Sales;

namespace UnitTestVelvetVogue.SalesTests
{
    public class OrderStaffAssignmentTestings
    {
        private readonly Mock<IGenericService<OrderStaffAssignment>> _sut;

        public OrderStaffAssignmentTestings()
        {
            _sut = new Mock<IGenericService<OrderStaffAssignment>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new OrderStaffAssignment();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<int>(entity.OrderId);
            Assert.IsType<int>(entity.StaffId);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new OrderStaffAssignment();

            // Act
            entity.Id = 1;
            entity.OrderId = 1;
            entity.StaffId = 1;

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal(1, entity.OrderId);
            Assert.Equal(1, entity.StaffId);
        }

        [Fact]
        public void Entity_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange
            var entity = new OrderStaffAssignment();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new OrderStaffAssignment();

            // Assert
            Assert.Equal(0, entity.Id);
            Assert.Equal(0, entity.OrderId);
            Assert.Equal(0, entity.StaffId);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Entity_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var entity = new OrderStaffAssignment();

            // Act
            entity.Id = id;
            entity.OrderId = id;
            entity.StaffId = id;

            // Assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(id, entity.OrderId);
            Assert.Equal(id, entity.StaffId);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new OrderStaffAssignment
            {
                Id = 1,
                OrderId = 1,
                StaffId = 1,
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<OrderStaffAssignment>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.OrderId, deserializedEntity.OrderId);
            Assert.Equal(originalEntity.StaffId, deserializedEntity.StaffId);
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new OrderStaffAssignment { Id = 1, OrderId = 1, StaffId = 1 };
            var createdEntity = new OrderStaffAssignment { Id = 1, OrderId = 1, StaffId = 1 };
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
            var entityToDelete = new OrderStaffAssignment { Id = entityIdToDelete };
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
            var expectedEntities = new List<OrderStaffAssignment>
            {
                new OrderStaffAssignment { Id = 1, OrderId = 1, StaffId = 1},
                new OrderStaffAssignment { Id = 2, OrderId = 2, StaffId = 2}
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
            var expectedEntity = new OrderStaffAssignment { Id = 1, OrderId = 1, StaffId = 1 };
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
            var expectedUpdatedEntity = new OrderStaffAssignment { Id = entityIdToUpdate, OrderId = 1, StaffId = 1 };
            var updatedEntity = new OrderStaffAssignment { Id = entityIdToUpdate, OrderId = 1, StaffId = 1 };

            _sut.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _sut.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            _sut.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.OrderId, actualUpdatedEntity.OrderId);
            Assert.Equal(expectedUpdatedEntity.StaffId, actualUpdatedEntity.StaffId);
        }

    }
}
