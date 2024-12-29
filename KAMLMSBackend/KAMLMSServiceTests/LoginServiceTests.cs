using Moq;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Helper;
using KAMLMSService.Interfaces;
using KAMLMSService.Services;
using NUnit.Framework;

namespace KAMLMSServiceTests
{
    [TestFixture]
    public class LoginServiceTests
    {
        private Mock<IAuthRepository> _mockAuthRepository;
        private Mock<IManagerService> _mockManagerService;
        private LoginService _loginService;

        [SetUp]
        public void Setup()
        {
            _mockAuthRepository = new Mock<IAuthRepository>();
            _mockManagerService = new Mock<IManagerService>();
            _loginService = new LoginService(_mockAuthRepository.Object, _mockManagerService.Object);
        }

        [Test]
        public void Login_ShouldReturnManagerEntity_WhenCredentialsAreValid()
        {
            // Arrange
            string email = "test@example.com";
            string password = "password";
            var user = new LoginEntity { Email = email, Password = PasswordHelper.HashPassword(password) };
            var manager = new ManagersEntity { Id = Guid.NewGuid(), Email = email };

            _mockAuthRepository.Setup(repo => repo.GetUser(email)).Returns(user);
            _mockManagerService.Setup(service => service.GetManagerByEmail(email)).Returns(manager);

            // Act
            var result = _loginService.login(email, password);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(manager.Id, result.Id);
            _mockAuthRepository.Verify(repo => repo.GetUser(email), Times.Once);
            _mockManagerService.Verify(service => service.GetManagerByEmail(email), Times.Once);
        }

        [Test]
        public void Login_ShouldThrowCustomException_WhenUserIsInvalid()
        {
            // Arrange
            string email = "invalid@example.com";
            string password = "password";
            _mockAuthRepository.Setup(repo => repo.GetUser(email)).Returns((LoginEntity)null);

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => _loginService.login(email, password));
            Assert.AreEqual("Invalid User", ex.Message);
            _mockAuthRepository.Verify(repo => repo.GetUser(email), Times.Once);
        }

        [Test]
        public void Login_ShouldThrowCustomException_WhenPasswordIsInvalid()
        {
            // Arrange
            string email = "test@example.com";
            string password = "wrongpassword";
            var user = new LoginEntity { Email = email, Password = PasswordHelper.HashPassword("password") };

            _mockAuthRepository.Setup(repo => repo.GetUser(email)).Returns(user);

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => _loginService.login(email, password));
            Assert.AreEqual("Invalid Login", ex.Message);
            _mockAuthRepository.Verify(repo => repo.GetUser(email), Times.Once);
        }

        [Test]
        public void SignUp_ShouldReturnManagerId_WhenUserIsSuccessfullyAdded()
        {
            // Arrange
            var request = new ManagerRequest { Email = "newuser@example.com", Password = "password" };
            var manager = new ManagersEntity { Id = Guid.NewGuid(), Email = request.Email };

            _mockAuthRepository.Setup(repo => repo.GetUser(request.Email)).Returns((LoginEntity)null);
            _mockManagerService.Setup(service => service.addManager(request)).Returns(manager);

            // Act
            var result = _loginService.SignUp(request);

            // Assert
            Assert.AreEqual(manager.Id, result);
            _mockAuthRepository.Verify(repo => repo.GetUser(request.Email), Times.Once);
            _mockAuthRepository.Verify(repo => repo.AddUser(It.IsAny<LoginEntity>()), Times.Once);
            _mockManagerService.Verify(service => service.addManager(request), Times.Once);
        }

        [Test]
        public void SignUp_ShouldThrowCustomException_WhenUserAlreadyExists()
        {
            // Arrange
            var request = new ManagerRequest { Email = "existinguser@example.com", Password = "password" };
            var existingUser = new LoginEntity { Email = request.Email };

            _mockAuthRepository.Setup(repo => repo.GetUser(request.Email)).Returns(existingUser);

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => _loginService.SignUp(request));
            Assert.AreEqual("User already exists", ex.Message);
            _mockAuthRepository.Verify(repo => repo.GetUser(request.Email), Times.Once);
            _mockAuthRepository.Verify(repo => repo.AddUser(It.IsAny<LoginEntity>()), Times.Never);
            _mockManagerService.Verify(service => service.addManager(It.IsAny<ManagerRequest>()), Times.Never);
        }
    }

}
