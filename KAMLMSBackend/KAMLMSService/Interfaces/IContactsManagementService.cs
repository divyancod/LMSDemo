using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;

namespace KAMLMSService.Interfaces
{
    public interface IContactsManagementService
    {
        void AddPOC(POCRequest request, string Userid);
        IList<ContactEntity> getPOC(Guid ContactEntity);
    }
}
