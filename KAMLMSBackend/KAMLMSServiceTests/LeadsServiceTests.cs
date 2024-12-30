using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Services;
using Moq;
using NUnit.Framework;

namespace KAMLMSServiceTests
{
    [TestFixture]
    public class LeadsServiceTests
    {
        private Mock<ILeadsRepository> _mockLeadsRepository;
        private Mock<ICallManagementRepository> callManagementRepositoryMock;
        private LeadsService _leadsService;

        [SetUp]
        public void Setup()
        {
            _mockLeadsRepository = new Mock<ILeadsRepository>();
            callManagementRepositoryMock = new Mock<ICallManagementRepository>();
            _leadsService = new LeadsService(_mockLeadsRepository.Object, callManagementRepositoryMock.Object);
        }

        [Test]
        public void AddLeads_ShouldThrowException_WhenParentEnterpriseNameIsEmpty()
        {
            // Arrange
            var leadsRequest = new LeadsRequest
            {
                ParentEnterpriseName = null,
                CompanyName = "Test Company",
                CompanyEmail = "test@example.com",
                CompanyAddress = "Test Address",
                Country = "Test Country",
                TimeZone = "Test TimeZone",
                WorkingHourStart = "09:00",
                WorkingHourEnd = "17:00"
            };

            // Act & Assert
            var ex = Assert.Throws<CustomException>(() => _leadsService.AddLeads(leadsRequest, Guid.NewGuid()));
            Assert.AreEqual("Parent Enterprise can not be empty", ex.Message);
        }

        [Test]
        public void AddLeads_ShouldAddLead_WhenValidRequestIsProvided()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var leadsRequest = new LeadsRequest
            {
                ParentEnterpriseName = "Enterprise",
                CompanyName = "Test Company",
                CompanyEmail = "test@example.com",
                CompanyAddress = "Test Address",
                Country = "Test Country",
                TimeZone = "Test TimeZone",
                WorkingHourStart = "09:00",
                WorkingHourEnd = "17:00",
                Comment = "Test Comment"
            };

            var leadEntity = new LeadsEntity
            {
                Id = Guid.NewGuid()
            };

            _mockLeadsRepository.Setup(repo => repo.AddLead(It.IsAny<LeadsEntity>())).Returns(leadEntity);

            // Act
            var result = _leadsService.AddLeads(leadsRequest, userId);

            // Assert
            Assert.AreEqual(leadEntity.Id, result);
            _mockLeadsRepository.Verify(repo => repo.AddLead(It.IsAny<LeadsEntity>()), Times.Once);
        }

        [Test]
        public void GetLead_ShouldReturnLead_WhenValidIdIsProvided()
        {
            // Arrange
            var leadId = Guid.NewGuid();
            var expectedLead = new LeadsEntity { Id = leadId, CompanyName = "Test Company" };

            _mockLeadsRepository.Setup(repo => repo.GetLead(leadId)).Returns(expectedLead);

            // Act
            var result = _leadsService.GetLead(leadId);

            // Assert
            Assert.AreEqual(expectedLead, result);
            _mockLeadsRepository.Verify(repo => repo.GetLead(leadId), Times.Once);
        }

        [Test]
        public void GetLeads_ShouldReturnListOfLeads_WhenCalled()
        {
            // Arrange
            var type = 1;
            var page = 1;
            var take = 10;
            //AssignedTo = item.AssignedTo.FullName, CompanyName = item.CompanyName, EnterpriseName = item.ParentEnterpriseName, Id = item.Id, Status = item.status.Status ,StatusId=item.StatusId
            ManagersEntity assignedTo = new ManagersEntity { FullName = "DIVYANSHU" };
            LeadStatusEntity statusEntity = new LeadStatusEntity { id = 1, Status = "New" };
            var leads = new List<LeadsEntity>
        {
            new LeadsEntity { Id = Guid.NewGuid(), CompanyName = "Company test 1", ParentEnterpriseName = "Enterprise test 1", AssignedTo = assignedTo, status = statusEntity, StatusId = 1 },
            new LeadsEntity { Id = Guid.NewGuid(), CompanyName = "Company test 2", ParentEnterpriseName = "Enterprise test 2", AssignedTo = assignedTo, status = statusEntity, StatusId = 1 }
        };


            _mockLeadsRepository.Setup(repo => repo.GetLeads(take, page, type)).Returns(leads);

            // Act
            var result = _leadsService.GetLeads(type, page, take);

            // Assert
            Assert.AreEqual(2, result.Count);
            _mockLeadsRepository.Verify(repo => repo.GetLeads(take, page, type), Times.Once);
        }

        [Test]
        public void UpdateLeadStatus_Should_Call_CancelAllCallsForLead()
        {
            // Arrange
            var leadId = Guid.NewGuid().ToString();
            var updateRequest = new UpdateLead
            {
                id = leadId,
                status = "2",
                comment = "Updated status"
            };

            var leadEntity = new LeadsEntity
            {
                Id = new Guid(updateRequest.id),
                StatusId = 1,
                Comment = "Initial comment"
            };

            _mockLeadsRepository.Setup(r => r.GetLead(It.IsAny<Guid>())).Returns(leadEntity);
            _mockLeadsRepository.Setup(r => r.UpdateLead(It.IsAny<LeadsEntity>())).Returns(leadEntity);

            // Act
            _leadsService.UpdateLeadStatus(updateRequest);

            // Assert
            _mockLeadsRepository.Verify(r => r.GetLead(It.Is<Guid>(g => g == new Guid(updateRequest.id))), Times.Once);
            _mockLeadsRepository.Verify(r => r.UpdateLead(It.Is<LeadsEntity>(e =>
                e.StatusId == int.Parse(updateRequest.status) &&
                e.Comment == updateRequest.comment)), Times.Once);

            callManagementRepositoryMock.Verify(cm => cm.CancelAllCallsForLead(It.Is<Guid>(g => g == new Guid(leadId))), Times.Once);
        }
     }
}
