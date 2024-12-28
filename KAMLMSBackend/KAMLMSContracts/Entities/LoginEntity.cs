using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    /// <summary>
    /// Table to initate manager login for quick login.
    /// </summary>
    [Table("tbl_master_login")]
    public class LoginEntity
    {
        //unique entry for login service
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// login email id
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Login password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Is user active and allowed to login?
        /// </summary>
        public Boolean IsActive { get; set; }
    }
}
