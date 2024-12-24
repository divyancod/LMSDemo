using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    [Table("tbl_poc_contacts")]
    public class ContactEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public LeadsEntity LeadsEntity { get; set; }
        [ForeignKey("LeadsEntity")]
        public Guid LeadsId { get; set; }

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

    [Table("tbl_poc_roles")]
    public class RolesEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [Table("tbl_poc_custom_roles")]
    public class CustomRoleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
