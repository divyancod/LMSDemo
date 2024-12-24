using KAMLMSContracts.Entities;

namespace KAMLMSRepository.Interfaces
{
    public interface ICallManagementRepository
    {
        int ScheduleCall(CallScheduleEntity request);
        IList<CallScheduleEntity> GetAllCallScheduledByPOC(Guid pocId);
        IList<CallScheduleEntity> GettAllCallScheduledByCompany(Guid companyId);
        IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status);
        IList<CallStatusEntity> GetAllCallStatusDetails();

    }
}
