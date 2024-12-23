using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    public class ContactEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public LeadsEntity LeadsEntity { get; set; }
        [ForeignKey("LeadsEntity")]
        public Guid LeadsEntityId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public RolesEntity Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("CustomRole")]
        public int CustomRoleId { get; set; }
        public CustomRoleEntity CustomRole { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("ManagersEntity")]
        public Guid AddedById { get; set; }
        public ManagersEntity ManagersEntity { get; set; }
    }

    public class RolesEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomRoleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
