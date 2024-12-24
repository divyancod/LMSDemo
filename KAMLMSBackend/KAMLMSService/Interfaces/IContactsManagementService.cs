using KAMLMSContracts.Entities;
using KAMLMSContracts.RequestModels;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSService.Interfaces
{
    public interface IContactsManagementService
    {
        void AddPOC(POCRequest request, string Userid);
        IList<ContactEntity> getPOC(Guid ContactEntity);
        IList<PocMinResponse> getPocMin(string CompanyId);
    }
}
