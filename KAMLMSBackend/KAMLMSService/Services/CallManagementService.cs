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
            int callFrequency = 1;
            int callGap = 1;

            if (request.CallFrequency==1)//daily
            {
                callGap = 1;
                callFrequency = 15;
            }
            if(request.CallFrequency==2)//weekly
            {
                callGap = 7;
                callFrequency = 4;
            }
            if(request.CallFrequency==3)//monthly
            {
                callGap = 30;
                callFrequency = 3;
            }
            var scheduledEntities = new List<CallScheduleEntity>();
            var currDate = DateTime.Parse(request.Time);
            for (int i=0;i<callFrequency;i++)
            {
                scheduledEntities.Add(new CallScheduleEntity
                {
                    ScheduledForId = new Guid(request.CompanyId),
                    ScheduledWithId = new Guid(request.PocId),
                    ScheduledById = new Guid(currentUser),
                    CallerId = new Guid(currentUser),
                    ScheduledAt = currDate,
                    Comment = string.IsNullOrEmpty(request.Comment) ? "NEW Call" : request.Comment,
                    CreatedAt = DateTime.Now,
                    CallStatusId = (int)CallStatusEnum.Scheduled
                });
                currDate = currDate.AddDays(callGap);
            }
            callManagementRepository.AddCallList(scheduledEntities);
            MoveLeadtoInProgressState(scheduledEntities[0].ScheduledForId);
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

        public IList<FollowUpResponse> GetFollowUpCallsList(string? day, string? month, string? year, int page, int take)
        {
            DateTime today = DateTime.Now;
            if(day==null)
            {
                day = today.Day.ToString();
            }
            if(month==null)
            {
                month = today.Month.ToString();
            }
            if(year==null)
            {
                year = today.Year.ToString();
            }
            return callManagementRepository.GetFollowUpCallsList(day, month, year,page, take);
        }

        public IList<FollowUpResponse> AtRisk(int page, int take)
        {
            var oldFolloups = callManagementRepository.AtRisk(page,take); //get leads who are not contacted for last 10 days
            var missed = callManagementRepository.MissedCalls(page, take - oldFolloups.Count); // get missed scheduled calls
            
            IList<FollowUpResponse> response = new List<FollowUpResponse>();
            IList<Guid> tracking = new List<Guid>();
            //add old and compare missed to add in list
            foreach(var item in oldFolloups)
            {
                response.Add(item);
                tracking.Add(item.CompanyId);
            }
            foreach (var item in missed)
            {
                if(!tracking.Contains(item.CompanyId))
                {
                    response.Add(item);
                }
            }
            return response;
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

        public void CancelAllCallsForLead(string leadId)
        {
            callManagementRepository.CancelAllCallsForLead(new Guid(leadId));
        }
    }
}
