using KAMLMSContracts.Entities;

namespace KAMLMSService.Interfaces
{
    public interface IDataControlService
    {
        IList<RolesEntity> getAllRoles();
    }
}
