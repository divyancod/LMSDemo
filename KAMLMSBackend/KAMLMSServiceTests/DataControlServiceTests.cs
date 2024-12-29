using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Services;
using Moq;
using NUnit.Framework;

namespace KAMLMSServiceTests
{
    [TestFixture]
    public class DataControlServiceTests
    {
        private Mock<IContanctRepository> _mockContactRepository;
        private Mock<IDataControlRepository> _mockDataControlRepository;
        private DataControlService _dataControlService;

        [SetUp]
        public void Setup()
        {
            // Initialize mocks
            _mockContactRepository = new Mock<IContanctRepository>();
            _mockDataControlRepository = new Mock<IDataControlRepository>();

            // Inject mocks into the service
            _dataControlService = new DataControlService(_mockContactRepository.Object, _mockDataControlRepository.Object);
        }

        [Test]
        public void GetAllCountries_ShouldReturnListOfCountries()
        {
            // Arrange
            var expectedCountries = new List<CountryEntity>
        {
            new CountryEntity { Id = 1, Country = "India" },
            new CountryEntity { Id = 2, Country = "USA" }
        };
            _mockDataControlRepository.Setup(repo => repo.GetAllCountryList()).Returns(expectedCountries);

            // Act
            var result = _dataControlService.getAllCountries();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedCountries.Count, result.Count);
            Assert.AreEqual(expectedCountries, result);
            _mockDataControlRepository.Verify(repo => repo.GetAllCountryList(), Times.Once);
        }

        [Test]
        public void GetAllRoles_ShouldReturnListOfRoles()
        {
            // Arrange
            var expectedRoles = new List<RolesEntity>
        {
            new RolesEntity { Id = 1, Name = "Admin" },
            new RolesEntity { Id = 2, Name = "User" }
        };
            _mockContactRepository.Setup(repo => repo.getAllRoles()).Returns(expectedRoles);

            // Act
            var result = _dataControlService.getAllRoles();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedRoles.Count, result.Count);
            Assert.AreEqual(expectedRoles, result);
            _mockContactRepository.Verify(repo => repo.getAllRoles(), Times.Once);
        }
    }

}