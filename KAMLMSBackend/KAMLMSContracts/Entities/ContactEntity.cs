using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    /// <summary>
    /// POC Entity of the added lead
    /// </summary>
    [Table("tbl_poc_contacts")]
    public class ContactEntity
    {
        /// <summary>
        /// Unique identifier for the contact.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Entity representing the lead associated with this contact.
        /// </summary>
        public LeadsEntity LeadsEntity { get; set; }

        /// <summary>
        /// Unique identifier of the lead/company associated with this contact.
        /// </summary>
        [ForeignKey("LeadsEntity")]
        public Guid LeadsId { get; set; }

        /// <summary>
        /// Name of the contact person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phone number of the contact person.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email address of the contact person.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Role entity representing the role of the contact.
        /// </summary>
        public RolesEntity Role { get; set; }

        /// <summary>
        /// Unique identifier for the role associated with the contact.
        /// </summary>
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        /// <summary>
        /// Unique identifier for the custom role associated with the contact.
        /// </summary>
        [ForeignKey("CustomRole")]
        public int CustomRoleId { get; set; }

        /// <summary>
        /// Custom role entity representing the specific role of the poc.
        /// </summary>
        public CustomRoleEntity CustomRole { get; set; }

        /// <summary>
        /// Date and time when the contact record was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the poc record was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Unique identifier of the manager who added this contact.
        /// </summary>
        [ForeignKey("ManagersEntity")]
        public Guid AddedById { get; set; }

        /// <summary>
        /// Entity of the manager who added this contact.
        /// </summary>
        public ManagersEntity ManagersEntity { get; set; }
    }
    /// <summary>
    /// POC role in the lead
    /// </summary>
    [Table("tbl_poc_roles")]
    public class RolesEntity
    {
        /// <summary>
        /// Unique identifier for the role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the role - Will be refered from Role enum in repository project.
        /// </summary>
        public string Name { get; set; }
    }
    /// <summary>
    /// If POC role is not in our DB flexibility to add custom role for the POC.
    /// </summary>
    [Table("tbl_poc_custom_roles")]
    public class CustomRoleEntity
    {
        /// <summary>
        /// Unique identifier for the custom role.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the custom role.
        /// </summary>
        public string Name { get; set; }
    }

}
