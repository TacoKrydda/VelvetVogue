using Moq;
using Newtonsoft.Json;
using WebbShopClassLibrary.Interfaces;
using WebbShopClassLibrary.Models.Sales;

namespace UnitTestVelvetVogue.SalesTests
{
    public class CustomerTestings
    {
        private readonly Mock<IGenericService<Customer>> _sut;

        public CustomerTestings()
        {
            _sut = new Mock<IGenericService<Customer>>();
        }

        [Fact]
        public void Entity_Properties_Have_Correct_Types()
        {
            // Arrange
            var entity = new Customer();

            // Assert
            Assert.IsType<int>(entity.Id);
            Assert.IsType<string>(entity.FirstName);
            Assert.IsType<string>(entity.LastName);
            Assert.IsType<string>(entity.Email);
            Assert.IsType<string>(entity.Phone);
            Assert.IsType<string>(entity.City);
            Assert.IsType<string>(entity.Street);
        }

        [Fact]
        public void Entity_Properties_Are_Gettable_Settable()
        {
            // Arrange
            var entity = new Customer();

            // Act
            entity.Id = 1;
            entity.FirstName = "Benny";
            entity.LastName = "Bobson";
            entity.Email = "BenBob@test.com";
            entity.Phone = "0123456789";
            entity.City = "Test City";
            entity.Street = "Test Street";

            // Assert
            Assert.Equal(1, entity.Id);
            Assert.Equal("Benny", entity.FirstName);
            Assert.Equal("Bobson", entity.LastName);
            Assert.Equal("BenBob@test.com", entity.Email);
            Assert.Equal("0123456789", entity.Phone);
            Assert.Equal("Test City", entity.City);
            Assert.Equal("Test Street", entity.Street);
        }

        [Fact]
        public void Entity_Can_Be_Constructed_With_Default_Constructor()
        {
            // Arrange
            var entity = new Customer();

            // Assert
            Assert.NotNull(entity);
        }

        [Fact]
        public void Entity_Properties_Are_Initialized_Correctly()
        {
            // Arrange & Act
            var entity = new Customer();

            // Assert
            Assert.Equal(0, entity.Id);
            Assert.Equal(string.Empty, entity.FirstName);
            Assert.Equal(string.Empty, entity.LastName);
            Assert.Equal(string.Empty, entity.Email);
            Assert.Equal(string.Empty, entity.Phone);
            Assert.Equal(string.Empty, entity.City);
            Assert.Equal(string.Empty, entity.Street);
        }

        [Theory]
        [InlineData(0)] // minsta tillåtna värde
        [InlineData(999)] // största tillåtna värde
        public void Entity_Id_Can_Be_Set_and_Get_Boundary(int id)
        {
            // Arrange
            var entity = new Customer();

            // Act
            entity.Id = id;

            // Assert
            Assert.Equal(id, entity.Id);
        }

        [Fact]
        public void Entity_Can_Be_Serialized_And_Deserialized()
        {
            // Arrange
            var originalEntity = new Customer
            {
                Id = 1,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };

            // Act
            var serializedEntity = JsonConvert.SerializeObject(originalEntity);
            var deserializedEntity = JsonConvert.DeserializeObject<Customer>(serializedEntity);

            // Assert
            Assert.Equal(originalEntity.Id, deserializedEntity.Id);
            Assert.Equal(originalEntity.FirstName, deserializedEntity.FirstName);
            Assert.Equal(originalEntity.LastName, deserializedEntity.LastName);
            Assert.Equal(originalEntity.Email, deserializedEntity.Email);
            Assert.Equal(originalEntity.Phone, deserializedEntity.Phone);
            Assert.Equal(originalEntity.City, deserializedEntity.City);
            Assert.Equal(originalEntity.Street, deserializedEntity.Street);
        }

        [Fact]
        public async Task CreateEntity_ValidEntity_ReturnsCreatedEntity()
        {
            // Arrange
            var expectedEntity = new Customer
            {
                Id = 1,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };

            var createdEntity = new Customer
            {
                Id = 1,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };

            _sut.Setup(service => service.CreateAsync(expectedEntity))
                               .ReturnsAsync(createdEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.CreateAsync(expectedEntity);

            // Assert
            _sut.Verify(service => service.CreateAsync(expectedEntity), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
            Assert.Equal(expectedEntity.FirstName, actualEntity.FirstName);
            Assert.Equal(expectedEntity.LastName, actualEntity.LastName);
            Assert.Equal(expectedEntity.Email, actualEntity.Email);
            Assert.Equal(expectedEntity.Phone, actualEntity.Phone);
            Assert.Equal(expectedEntity.City, actualEntity.City);
            Assert.Equal(expectedEntity.Street, actualEntity.Street);
        }

        [Fact]
        public async Task DeleteEntity_ExistingEntity_ReturnsDeletedEntity()
        {
            // Arrange
            var entityIdToDelete = 1;
            var entityToDelete = new Customer { Id = entityIdToDelete };
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
            var expectedEntities = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Benny",
                    LastName = "Bobson",
                    Email = "BenBob@test.com",
                    Phone = "0123456789",
                    City = "Test City",
                    Street = "Test Street",
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "jenny",
                    LastName = "jobson",
                    Email = "jenjob@test.com",
                    Phone = "9876543210",
                    City = "Test City 2",
                    Street = "Test Street 2",
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
            var expectedEntity = new Customer
            {
                Id = entityId,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };
            _sut.Setup(service => service.GetByIdAsync(entityId))
                               .ReturnsAsync(expectedEntity);

            var entityService = _sut.Object;

            // Act
            var actualEntity = await entityService.GetByIdAsync(entityId);

            // Assert
            _sut.Verify(service => service.GetByIdAsync(entityId), Times.Once);
            Assert.Equal(expectedEntity.Id, actualEntity.Id);
            Assert.Equal(expectedEntity.FirstName, actualEntity.FirstName);
            Assert.Equal(expectedEntity.LastName, actualEntity.LastName);
            Assert.Equal(expectedEntity.Email, actualEntity.Email);
            Assert.Equal(expectedEntity.Phone, actualEntity.Phone);
            Assert.Equal(expectedEntity.City, actualEntity.City);
            Assert.Equal(expectedEntity.Street, actualEntity.Street);
        }

        [Fact]
        public async Task UpdateEntity_ValidEntity_ReturnsUpdatedEntity()
        {
            // Arrange
            var entityIdToUpdate = 1;
            var expectedUpdatedEntity = new Customer
            {
                Id = entityIdToUpdate,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };
            var updatedEntity = new Customer
            {
                Id = entityIdToUpdate,
                FirstName = "Benny",
                LastName = "Bobson",
                Email = "BenBob@test.com",
                Phone = "0123456789",
                City = "Test City",
                Street = "Test Street",
            };

            _sut.Setup(service => service.UpdateAsync(entityIdToUpdate, updatedEntity))
                               .ReturnsAsync(updatedEntity);

            var entityService = _sut.Object;

            // Act
            var actualUpdatedEntity = await entityService.UpdateAsync(entityIdToUpdate, updatedEntity);

            // Assert
            _sut.Verify(service => service.UpdateAsync(entityIdToUpdate, updatedEntity), Times.Once);
            Assert.Equal(expectedUpdatedEntity.Id, actualUpdatedEntity.Id);
            Assert.Equal(expectedUpdatedEntity.FirstName, actualUpdatedEntity.FirstName);
            Assert.Equal(expectedUpdatedEntity.LastName, actualUpdatedEntity.LastName);
            Assert.Equal(expectedUpdatedEntity.Email, actualUpdatedEntity.Email);
            Assert.Equal(expectedUpdatedEntity.Phone, actualUpdatedEntity.Phone);
            Assert.Equal(expectedUpdatedEntity.City, actualUpdatedEntity.City);
            Assert.Equal(expectedUpdatedEntity.Street, actualUpdatedEntity.Street);
        }

    }
}
