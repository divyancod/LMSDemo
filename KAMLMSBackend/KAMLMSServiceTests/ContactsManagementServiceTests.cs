using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;
using KAMLMSService.Services;
using Moq;
using NUnit.Framework;


namespace KAMLMSServiceTests
{
    [TestFixture]
    public class ContactsManagementServiceTests
    {
        private Mock<IContanctRepository> _mockContactRepo;
        private Mock<ICallManagementService> _mockCallManagementService;
        private ContactsManagementService _service;

        [SetUp]
        public void Setup()
        {
            _mockContactRepo = new Mock<IContanctRepository>();
            _mockCallManagementService = new Mock<ICallManagementService>();
            _service = new ContactsManagementService(_mockContactRepo.Object, _mockCallManagementService.Object);
        }

        [Test]
        public void AddPOC_ShouldThrowException_WhenNameIsNull()
        {
            // Arrange
            var request = new POCRequest
            {
                Name = null,
                Email = "test@example.com"
            };

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => _service.AddPOC(request, Guid.NewGuid().ToString()));
            Assert.AreEqual("Name can not be null", ex.Message);
        }

        [Test]
        public void AddPOC_ShouldAddContactAndScheduleCalls_WhenIsMainPOCIsTrue()
        {
            // Arrange
            var request = new POCRequest
            {
                Name = "Test Name",
                Email = "test@example.com",
                Phone = "1234567890",
                CompanyId = Guid.NewGuid(),
                RoleId = 1,
                IsMainPOC = true,
                Time = DateTime.Now.ToString()
            };

            var addedEntity = new ContactEntity
            {
                Id = Guid.NewGuid(),
                LeadsId = request.CompanyId,
                Name = request.Name
            };

            _mockContactRepo
                .Setup(repo => repo.addContact(It.IsAny<ContactEntity>()))
                .Returns(addedEntity);

            // Act
            _service.AddPOC(request, Guid.NewGuid().ToString());

            // Assert
            _mockContactRepo.Verify(repo => repo.addContact(It.IsAny<ContactEntity>()), Times.Once);
            _mockCallManagementService.Verify(service => service.ScheduleCall(It.IsAny<CallScheduleRequest>(), It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void getPOC_ShouldReturnListOfContacts()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var expectedContacts = new List<ContactEntity>
        {
            new ContactEntity { Id = Guid.NewGuid(), LeadsId = companyId, Name = "Contact 1" },
            new ContactEntity { Id = Guid.NewGuid(), LeadsId = companyId, Name = "Contact 2" }
        };

            _mockContactRepo.Setup(repo => repo.GetPOC(companyId)).Returns(expectedContacts);

            // Act
            var result = _service.getPOC(companyId);

            // Assert
            Assert.AreEqual(expectedContacts, result);
            _mockContactRepo.Verify(repo => repo.GetPOC(companyId), Times.Once);
        }

        [Test]
        public void getPocMin_ShouldReturnMinimalPOCResponse()
        {
            // Arrange
            var companyId = Guid.NewGuid().ToString();
            var expectedResponse = new List<PocMinResponse>
        {
            new PocMinResponse { Id = Guid.NewGuid(), PocName = "POC 1" },
            new PocMinResponse { Id = Guid.NewGuid(), PocName = "POC 2" }
        };

            _mockContactRepo.Setup(repo => repo.getPocMin(new Guid(companyId))).Returns(expectedResponse);

            // Act
            var result = _service.getPocMin(companyId);

            // Assert
            Assert.AreEqual(expectedResponse, result);
            _mockContactRepo.Verify(repo => repo.getPocMin(new Guid(companyId)), Times.Once);
        }
    }

}