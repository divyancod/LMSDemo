using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    /// <summary>
    /// Primary table for users of the application storing managers information
    /// </summary>
    [Table("tbl_kam_users")]
    public class ManagersEntity
    {
        /// <summary>
        /// Manager unique id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the manager
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Full name of the manager
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Exact position currently default (eg- Account manager, associate, Manager, Lead Manager)
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Manager phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// When manager was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        /// <summary>
        /// Manager update at?
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
