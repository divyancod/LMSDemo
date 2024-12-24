
using KAMLMSContracts.Entities;
using KAMLMSRepository.Interfaces;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace KAMLMSRepository.Repositories
{
    public class CallManagementRepository : BaseRepository, ICallManagementRepository
    {
        public CallManagementRepository(DatabaseContext context) : base(context)
        {
        }

        public IList<CallScheduleEntity> GetAllCallScheduledByPOC(Guid pocId)
        {
            return databaseContext.CallScheduleEntity.Where(x => x.ScheduledWithId == pocId).ToList();

        }

        public IList<CallScheduleEntity> GetAllCallScheduledByStatus(int status)
        {
            return databaseContext.CallScheduleEntity.Where(x => x.CallStatusId == status).ToList();
        }

        public IList<CallStatusEntity> GetAllCallStatusDetails()
        {
            return databaseContext.CallStatusEntity.ToList();
        }

        public IList<CallScheduleEntity> GettAllCallScheduledByCompany(Guid companyId)
        {
            return databaseContext.CallScheduleEntity.Where(x => x.ScheduledForId == companyId).ToList();
        }

        public int ScheduleCall(CallScheduleEntity request)
        {
            databaseContext.CallScheduleEntity.Add(request);
            databaseContext.SaveChanges();
            return request.CallScheduleId;
        }
    }
}
