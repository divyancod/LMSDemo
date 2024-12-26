using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Constants;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class CallManagementService : ICallManagementService
    {
        private ICallManagementRepository callManagementRepository;
        private ILeadsService leadsService;

        public CallManagementService(ICallManagementRepository repo,ILeadsService leadsService)
        {
            callManagementRepository = repo;
            this.leadsService = leadsService;
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

        public IList<CallScheduledResponse> GettAllCallScheduledByCompany(string companyId, int page, int take, CallFilters filter)
        {
            return callManagementRepository.GettAllCallScheduledByCompany(new Guid(companyId), page, take, filter);
        }

        public int ScheduleCall(CallScheduleRequest request, string currentUser)
        {
            if (string.IsNullOrEmpty(request.PocId))
            {
                throw new CustomException("Invalid POC ID");
            }
            if (string.IsNullOrEmpty(request.CompanyId))
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
                Comment = string.IsNullOrEmpty(request.Comment) ? "NEW Call" : request.Comment,
                CreatedAt = DateTime.Now,
                CallStatusId = (int)CallStatusEnum.Scheduled
            };
            callManagementRepository.ScheduleCall(entity);
            MoveLeadtoInProgressState(entity.ScheduledForId);
            return 0;
        }

        public void UpdateCallStatus(UpdateCallScheduleRequest request)
        {
            CallScheduleEntity entity = callManagementRepository.GetCallStatusById(int.Parse(request.CallId));
            //create new call schedule
            if (!string.IsNullOrEmpty(request.ReScheduleDate))
            {
                CallScheduleRequest newCall = new CallScheduleRequest
                {
                    CompanyId = entity.ScheduledForId.ToString(),
                    PocId = entity.ScheduledWithId.ToString(),
                    Time = request.ReScheduleDate,
                    Comment = $"Re-Scheduled call - {entity.Comment}"
                };
                ScheduleCall(newCall, entity.ScheduledById.ToString());
            }
            entity.CallStatusId = int.Parse(request.StatusId);
            entity.Comment = string.IsNullOrEmpty(request.Comment) ? entity.Comment : request.Comment;
            callManagementRepository.UpdateCallStatus(entity);
        }

        public IList<FollowUpResponse> GetFollowUpCallsList(string? day, string? month, string? year)
        {
            DateTime today = DateTime.Now;
            if(month==null)
            {
                month = today.Month.ToString();
            }
            if(year==null)
            {
                year = today.Year.ToString();
            }
            return callManagementRepository.GetFollowUpCallsList(day, month, year);
        }

        public IList<FollowUpResponse> AtRisk()
        {
            return callManagementRepository.AtRisk();
        }

        private void MoveLeadtoInProgressState(Guid leadId)
        {
            LeadsEntity entity = leadsService.GetLead(leadId);
            if(entity.StatusId!=(int)LeadStatus.InProgress)
            {
                entity.StatusId = (int)LeadStatus.InProgress;
                entity.ModifiedAt = DateTime.Now;
                leadsService.UpdateLead(entity);
            }  
        }
    }
}
