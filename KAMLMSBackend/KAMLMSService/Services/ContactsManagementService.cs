using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSRepository.Interfaces;
using KAMLMSService.Exceptions;
using KAMLMSService.Interfaces;

namespace KAMLMSService.Services
{
    public class ContactsManagementService : IContactsManagementService
    {
        private IContanctRepository contactRepo;
        public ContactsManagementService(IContanctRepository repo)
        {
            contactRepo = repo;
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
                CustomRoleId = getCustomRole(request.RoleId,request.CustomRole),//todo add custom role
                AddedById = new Guid(user),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            contactRepo.addContact(entity);
        }

        public IList<ContactEntity> getPOC(Guid CompanyId)
        {
            return contactRepo.GetPOC(CompanyId);
        }

        private int getCustomRole(int roleId, string CustomRole)
        {
            if(roleId==11 && !string.IsNullOrEmpty(CustomRole)) // ADDING CUSTOM ROLE
            {
                return contactRepo.addCustomRole(CustomRole);
            }else
            {
                return 1;// DEFAULT
            }
        }
    }
}
