using Xunit;
using Moq;
using Services.Services;
using DataAccessLayer.Repository;
using BusinessObjects.Entity;

namespace Services.Test
{
    public class RepositoryServiceTest
    {
        [Fact]
        public void RegisterRepository_ShouldStoreRepository()
        {
            var repositoryManager = new RepositoryManager();
            var mockRepo = new Mock<IGenericRepository<DummyEntity>>(); // Mock

            var dummyList = new List<DummyEntity>
            {
                new DummyEntity { Id = 1 }
            };
            mockRepo.Setup(r => r.GetAll()).Returns(dummyList);

            // Register Mocked Repository
            repositoryManager.RegisterRepository(mockRepo.Object);
            var all = repositoryManager.GetAll<DummyEntity>();

            Assert.NotNull(all);
        }

        [Fact]
        public void GetAll_ShouldReturnAllItemsFromRepository()
        {

            var repositoryManager = new RepositoryManager();
            var expected = new List<DummyEntity> // Values Expected
            {
                new DummyEntity { Id = 1 },
                new DummyEntity { Id = 2 }
            };

            var mockRepo = new Mock<IGenericRepository<DummyEntity>>(); // Mock
            mockRepo.Setup(r => r.GetAll()).Returns(expected);

            repositoryManager.RegisterRepository(mockRepo.Object);

            var actual = repositoryManager.GetAll<DummyEntity>();

            Assert.Equal(expected, actual);
            mockRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public void GetById_ShouldReturnCorrectEntity()
        {
            var repositoryManager = new RepositoryManager();
            var dummy = new DummyEntity { Id = 42 };

            var mockRepo = new Mock<IGenericRepository<DummyEntity>>(); // Mock
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).Returns((int id) => id == 42 ? dummy : null);

            repositoryManager.RegisterRepository(mockRepo.Object);

            var result = repositoryManager.GetById<DummyEntity>(42);

            Assert.Equal(dummy, result);
            mockRepo.Verify(r => r.Get(42), Times.Once);
        }

        [Fact]
        public void GetById_ShouldReturnNullIfNotFound()
        {
            var repositoryManager = new RepositoryManager();
            var mockRepo = new Mock<IGenericRepository<DummyEntity>>(); // Mock
            mockRepo.Setup(r => r.Get(It.IsAny<int>())).Returns((DummyEntity)null);

            repositoryManager.RegisterRepository(mockRepo.Object);

            var result = repositoryManager.GetById<DummyEntity>(999);

            Assert.Null(result);
            mockRepo.Verify(r => r.Get(999), Times.Once);
        }

        [Fact]
        public void GetAll_ShouldThrowIfNoRepositoryRegistered()
        {
            var repositoryManager = new RepositoryManager();

            Assert.Throws<InvalidOperationException>(() => repositoryManager.GetAll<DummyEntity>());
        }
    }

    // Testing Entity
    public class DummyEntity : IEntity
    {
        public int Id { get; set; }
    }
}
