using Moq;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Services;
using NUnit.Framework;

namespace KAMLMSServiceTests
{

    [TestFixture]
    public class ManagerServiceTests
    {
        private Mock<IManagerRepository> _mockRepository;
        private ManagerService _managerService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IManagerRepository>();
            _managerService = new ManagerService(_mockRepository.Object);
        }

        [Test]
        public void AddManager_ShouldReturnManagerEntity_WhenManagerIsSuccessfullyAdded()
        {
            // Arrange
            var request = new ManagerRequest
            {
                Email = "test@test.com",
                FullName = "John Doe",
                Phone = "1234567890"
            };

            var expectedEntity = new ManagersEntity
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FullName = request.FullName,
                Phone = request.Phone,
                Position = "Account Manager",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockRepository.Setup(repo => repo.AddManager(It.IsAny<ManagersEntity>())).Returns(expectedEntity);

            // Act
            var result = _managerService.addManager(request);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedEntity.Id, result.Id);
            _mockRepository.Verify(repo => repo.AddManager(It.IsAny<ManagersEntity>()), Times.Once);
        }

        [Test]
        public void GetManagerByEmail_ShouldReturnManagerEntity_WhenManagerExists()
        {
            // Arrange
            string email = "test@test.com";
            var expectedEntity = new ManagersEntity
            {
                Id = Guid.NewGuid(),
                Email = email,
                FullName = "John Doe",
                Phone = "1234567890",
                Position = "Account Manager",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockRepository.Setup(repo => repo.GetManagerByEmail(email)).Returns(expectedEntity);

            // Act
            var result = _managerService.GetManagerByEmail(email);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedEntity.Id, result.Id);
            _mockRepository.Verify(repo => repo.GetManagerByEmail(email), Times.Once);
        }

        [Test]
        public void GetManagerByEmail_ShouldReturnNull_WhenManagerDoesNotExist()
        {
            // Arrange
            string email = "test@test.com";

            _mockRepository.Setup(repo => repo.GetManagerByEmail(email)).Returns((ManagersEntity)null);

            // Act
            var result = _managerService.GetManagerByEmail(email);

            // Assert
            Assert.IsNull(result);
            _mockRepository.Verify(repo => repo.GetManagerByEmail(email), Times.Once);
        }
    }

}
