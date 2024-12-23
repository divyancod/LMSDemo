using KAMLMSContracts.RequestModels;

namespace KAMLMSService.Interfaces
{
    public interface IContactsManagementService
    {
        void AddPOC(POCRequest request);
    }
}
