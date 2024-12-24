
using KAMLMSContracts.Entities;
using KAMLMSContracts.ResponseModels;

namespace KAMLMSRepository.Interfaces
{
    public interface IContanctRepository
    {
        ContactEntity addContact(ContactEntity entity);
        IList<RolesEntity> getAllRoles();
        int addCustomRole(string customRole);
        IList<ContactEntity> GetPOC(Guid companyId);
        IList<PocMinResponse> getPocMin(Guid CompanyId);
    }
}
