using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Constants;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class CallManagementService : ICallManagementService
    {
        private ICallManagementRepository callManagementRepository;

        public CallManagementService(ICallManagementRepository repo)
        {
            callManagementRepository = repo;
        }
        public IList<CallScheduleEntity> GetAllCallScheduledByPOC(string pocId)
        {
            return callManagementRepository.GetAllCallScheduledByPOC(new Guid(pocId));
        }

        public IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status)
        {
            return callManagementRepository.GetAllCallScheduledByStatus(status);
        }

        public IList<CallStatusEntity> GetAllCallStatusDetails()
        {
            return callManagementRepository.GetAllCallStatusDetails();
        }

        public IList<CallScheduleEntity> GettAllCallScheduledByCompany(string companyId)
        {
            return callManagementRepository.GettAllCallScheduledByCompany(new Guid(companyId));
        }

        public int ScheduleCall(CallScheduleRequest request, string currentUser)
        {
            if(string.IsNullOrEmpty(request.PocId))
            {
                throw new CustomException("Invalid POC ID");
            }
            if(string.IsNullOrEmpty(request.CompanyId))
            {
                throw new CustomException("Invalid POC ID");
            }
            if (string.IsNullOrEmpty(request.Time))
            {
                throw new CustomException("Invalid POC ID");
            }
            CallScheduleEntity entity = new CallScheduleEntity
            {
                ScheduledForId = new Guid(request.CompanyId),
                ScheduledWithId = new Guid(request.PocId),
                ScheduledById = new Guid(currentUser),
                CallerId = new Guid(currentUser),
                ScheduledAt = DateTime.Parse(request.Time),
                Comment = request.Comment,
                CreatedAt = DateTime.Now,
                CallStatusId = (int)CallStatusEnum.Scheduled
            };
            callManagementRepository.ScheduleCall(entity);
            return 0;
        }
    }
}
