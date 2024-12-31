using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Constants;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Interfaces;
using KAMLMSService.Services;
using Moq;
using NUnit.Framework;
namespace KAMLMSServiceTests
{
    [TestFixture]
    public class CallManagementServiceTests
    {
        private Mock<ICallManagementRepository> callManagementRepositoryMock;
        private Mock<ILeadsService> leadsServiceMock;
        private CallManagementService callManagementService;

        [SetUp]
        public void Setup()
        {
            callManagementRepositoryMock = new Mock<ICallManagementRepository>();
            leadsServiceMock = new Mock<ILeadsService>();
            callManagementService = new CallManagementService(callManagementRepositoryMock.Object, leadsServiceMock.Object);
        }

        [Test]
        public void GetAllCallScheduledByPOC_Should_Return_Correct_Results()
        {
            // Arrange
            var pocId = Guid.NewGuid();
            var expectedCalls = new List<CallScheduleEntity>
        {
            new CallScheduleEntity { CallScheduleId = 1 }
        };
            callManagementRepositoryMock.Setup(repo => repo.GetAllCallScheduledByPOC(pocId)).Returns(expectedCalls);

            // Act
            var result = callManagementService.GetAllCallScheduledByPOC(pocId.ToString());

            // Assert
            Assert.AreEqual(expectedCalls, result);
        }

        [Test]
        public void GetAllCallScheduledByStatus_Should_Return_Correct_Results()
        {
            // Arrange
            int status = 1;
            var expectedCalls = new List<CallScheduleEntity>
        {
            new CallScheduleEntity { CallScheduleId = 1, CallStatusId = status }
        };
            callManagementRepositoryMock.Setup(repo => repo.GetAllCallScheduledByStatus(status)).Returns(expectedCalls);

            // Act
            var result = callManagementService.GetAllCallScheduledByStatus(status);

            // Assert
            Assert.AreEqual(expectedCalls, result);
        }

        [Test]
        public void GetAllCallStatusDetails_Should_Return_Correct_StatusDetails()
        {
            // Arrange
            var expectedStatuses = new List<CallStatusEntity>
        {
            new CallStatusEntity { Id = 1, Status = "Scheduled" }
        };
            callManagementRepositoryMock.Setup(repo => repo.GetAllCallStatusDetails()).Returns(expectedStatuses);

            // Act
            var result = callManagementService.GetAllCallStatusDetails();

            // Assert
            Assert.AreEqual(expectedStatuses, result);
        }

        [Test]
        public void ScheduleCall_Should_Call_Repository_And_Move_Lead_To_InProgress()
        {
            // Arrange
            var request = new CallScheduleRequest
            {
                CompanyId = Guid.NewGuid().ToString(),
                PocId = Guid.NewGuid().ToString(),
                Time = DateTime.Now.ToString(),
                Comment = "Test Comment"
            };
            var userId = Guid.NewGuid().ToString();
            leadsServiceMock.Setup(service => service.GetLead(It.IsAny<Guid>())).Returns(new LeadsEntity());

            // Act
            callManagementService.ScheduleCall(request, userId);

            // Assert
            callManagementRepositoryMock.Verify(repo => repo.AddCallList(It.IsAny<IList<CallScheduleEntity>>()), Times.Once);
            leadsServiceMock.Verify(service => service.UpdateLead(It.IsAny<LeadsEntity>()), Times.Once);
        }

        [Test]
        public void UpdateCallStatus_Should_Update_Status_And_Schedule_New_Call()
        {
            // Arrange
            var request = new UpdateCallScheduleRequest
            {
                CallId = "1",
                ReScheduleDate = DateTime.Now.AddDays(1).ToString(),
                StatusId = "2",
                Comment = "Rescheduled"
            };

            var existingCall = new CallScheduleEntity
            {
                CallScheduleId = 1,
                ScheduledForId = Guid.NewGuid(),
                ScheduledWithId = Guid.NewGuid(),
                ScheduledById = Guid.NewGuid(),
                CallStatusId = 1,
                Comment = "Initial"
            };
            LeadsEntity leads = new LeadsEntity
            {
                StatusId = (int)LeadStatus.InProgress,
                ModifiedAt = DateTime.Now
            };
            leadsServiceMock.Setup(repo => repo.GetLead(It.IsAny<Guid>())).Returns(leads);
            leadsServiceMock.Setup(repo => repo.UpdateLead(It.IsAny<LeadsEntity>())).Returns(leads);
                

            callManagementRepositoryMock.Setup(repo => repo.GetCallStatusById(It.IsAny<int>())).Returns(existingCall);

            // Act
            callManagementService.UpdateCallStatus(request);

            // Assert
            callManagementRepositoryMock.Verify(repo => repo.UpdateCallStatus(It.IsAny<CallScheduleEntity>()), Times.Once);
            callManagementRepositoryMock.Verify(repo => repo.AddCallList(It.IsAny<IList<CallScheduleEntity>>()), Times.Once);
        }

        [Test]
        public void GetFollowUpCallsList_Should_Return_FollowUp_Calls()
        {
            // Arrange
            var followUpCalls = new List<FollowUpResponse>
        {
            new FollowUpResponse { CompanyId = Guid.NewGuid() }
        };
            callManagementRepositoryMock.Setup(repo => repo.GetFollowUpCallsList(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(followUpCalls);

            // Act
            var result = callManagementService.GetFollowUpCallsList(null, null, null, 1, 10);

            // Assert
            Assert.AreEqual(followUpCalls, result);
        }

        [Test]
        public void AtRisk_Should_Return_AtRisk_Calls()
        {
            // Arrange
            var oldFollowUps = new List<FollowUpResponse>
        {
            new FollowUpResponse { CompanyId = Guid.NewGuid() }
        };
            var missedCalls = new List<FollowUpResponse>
        {
            new FollowUpResponse { CompanyId = Guid.NewGuid() }
        };
            callManagementRepositoryMock.Setup(repo => repo.AtRisk(It.IsAny<int>(), It.IsAny<int>())).Returns(oldFollowUps);
            callManagementRepositoryMock.Setup(repo => repo.MissedCalls(It.IsAny<int>(), It.IsAny<int>())).Returns(missedCalls);

            // Act
            var result = callManagementService.AtRisk(1, 10);

            // Assert
            Assert.AreEqual(2, result.Count); // Assuming no overlaps
        }

        [Test]
        public void CancelAllCallsForLead_Should_Call_Repository()
        {
            // Arrange
            var leadId = Guid.NewGuid().ToString();

            // Act
            callManagementService.CancelAllCallsForLead(leadId);

            // Assert
            callManagementRepositoryMock.Verify(repo => repo.CancelAllCallsForLead(It.Is<Guid>(id => id.ToString() == leadId)), Times.Once);
        }
    }

}
