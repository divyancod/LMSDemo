
using Azure;
using Azure.Core;
using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Interfaces;
using System.Linq;

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

        public IList<CallScheduledResponse> GettAllCallScheduledByCompany(Guid companyId, int page, int take, CallFilters filter)
        {
            var query = databaseContext.CallScheduleEntity
                            .OrderByDescending(cs => cs.ScheduledAt)
                            .Where(x => x.ScheduledForId == companyId);
            if (filter != null && filter.statusList != null && filter.statusList.Length != 0)
            {
                int[] statusArray = filter.statusList.Select(s => int.Parse(s)).ToArray();

                query = query.Where(x => statusArray.Contains(x.CallStatusId));
            }

            var result = query.Select(cs => new CallScheduledResponse
            {
                CallScheduleId = cs.CallScheduleId,
                ScheduledWithName = cs.ScheduledWith.Name,
                ScheduledWithPhone = cs.ScheduledWith.Phone,
                CallerName = cs.Caller.FullName,
                ScheduledAt = cs.ScheduledAt,
                Comment = cs.Comment,
                CallStatusId = cs.CallStatusId,
                CallStatusName = cs.CallStatus.Status
            }).Skip(page * take).Take(take);
            return result.ToList();
        }

        public int ScheduleCall(CallScheduleEntity request)
        {
            databaseContext.CallScheduleEntity.Add(request);
            databaseContext.SaveChanges();
            return request.CallScheduleId;
        }

        public void UpdateCallStatus(CallScheduleEntity request)
        {
            databaseContext.CallScheduleEntity.Update(request);
            databaseContext.SaveChanges();
        }

        public CallScheduleEntity GetCallStatusById(int id)
        {
            return databaseContext.CallScheduleEntity.FirstOrDefault(x => x.CallScheduleId == id);
        }

        public IList<FollowUpResponse> GetFollowUpCallsList(string day, string month, string year)
        {
            var query = databaseContext.CallScheduleEntity.OrderBy(cs => cs.ScheduledAt).Where(x => x.CallStatusId == 1);
            if (day != null)
            {
                query = query.Where(x => x.ScheduledAt.Day.ToString() == day);
            }
            query = query.Where(x => x.ScheduledAt.Month.ToString() == month).Where(x => x.ScheduledAt.Year.ToString() == year);
            var result = query.Select(x => new FollowUpResponse
            {
                Name = x.ScheduledFor.CompanyName,
                FollowupDate = x.ScheduledAt.ToString(),
                id = x.CallScheduleId,
                CompanyId = x.ScheduledFor.Id
            }).Take(5).ToList();
            return result;
        }
        public IList<FollowUpResponse> AtRisk()
        {
            var threeDayAgo = DateTime.Now.AddDays(-3);
            var query = databaseContext.CallScheduleEntity.GroupBy(x => x.ScheduledForId).Where(x => x.Max(x => x.ScheduledAt) < threeDayAgo).Select((x => new FollowUpResponse
            {
                Name = x.FirstOrDefault().ScheduledFor.CompanyName,
                FollowupDate = x.FirstOrDefault().ScheduledAt.ToString(),
                id = x.FirstOrDefault().CallScheduleId,
                CompanyId = x.FirstOrDefault().ScheduledFor.Id
            }));
            return query.ToList();
        }
    }
}
