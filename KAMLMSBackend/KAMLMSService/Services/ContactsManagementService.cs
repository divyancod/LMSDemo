using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class ContactsManagementService : IContactsManagementService
    {
        private IContanctRepository contactRepo;
        private ICallManagementService callManagementService;
        public ContactsManagementService(IContanctRepository repo, ICallManagementService callManagementService)
        {
            contactRepo = repo;
            this.callManagementService = callManagementService;
        }

        public void AddPOC(POCRequest request, string user)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new CustomException("Name can not be null");
            }
            if (string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.Phone))
            {
                throw new CustomException("Add atleast one conact details");
            }

            ContactEntity entity = new ContactEntity
            {
                LeadsId = request.CompanyId,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                RoleId = request.RoleId,
                CustomRoleId = getCustomRole(request.RoleId, request.CustomRole),//todo add custom role
                AddedById = new Guid(user),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            entity = contactRepo.addContact(entity);
            if (request.IsMainPOC != null && request.IsMainPOC == true)
            {
                ScheduleCallWithHotLeads(entity,user);
            }
        }

        private void ScheduleCallWithHotLeads(ContactEntity entity, string user)
        {
            //Scheduling introduction call
            CallScheduleRequest callSchedule = new CallScheduleRequest
            {
                CompanyId = entity.LeadsId.ToString(),
                PocId = entity.Id.ToString(),
                Time = DateTime.Today.AddDays(1).ToString(),
                Comment = "Introduction Call"
            };
            callManagementService.ScheduleCall(callSchedule, user);
            //Scheduling FollowUP Call
            CallScheduleRequest callSchedule2 = new CallScheduleRequest
            {
                CompanyId = entity.LeadsId.ToString(),
                PocId = entity.Id.ToString(),
                Time = DateTime.Today.AddDays(3).ToString(),
                Comment = "Follow up / Demo Call"
            };
            callManagementService.ScheduleCall(callSchedule2, user);
        }

        public IList<ContactEntity> getPOC(Guid CompanyId)
        {
            return contactRepo.GetPOC(CompanyId);
        }

        public IList<PocMinResponse> getPocMin(string CompanyId)
        {
            return contactRepo.getPocMin(new Guid(CompanyId));
        }

        private int getCustomRole(int roleId, string CustomRole)
        {
            if (roleId == 11 && !string.IsNullOrEmpty(CustomRole)) // ADDING CUSTOM ROLE
            {
                return contactRepo.addCustomRole(CustomRole);
            }
            else
            {
                return 1;// DEFAULT
            }
        }
    }
}
