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
        public void AddPOC(POCRequest request)
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                throw new CustomException("Name can not be null");
            }
            if(string.IsNullOrEmpty(request.Email) && string.IsNullOrEmpty(request.Phone))
            {
                throw new CustomException("Add atleast one conact details");
            }

            ContactEntity entity = new ContactEntity
            {
                LeadsEntityId = request.ResturantId,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                RoleId = (int)request.RoleId,
                CustomRoleId = 1,//todo add custom role
                AddedById = new Guid("F3BB025F-A461-40CA-B84D-08DD23642A24"),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
                
            };
            contactRepo.addContact(entity);

        }
    }
}
