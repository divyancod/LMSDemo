using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAMLMSContracts.Entities
{
    /// <summary>
    /// Countries and there respective timezone in order to schedule call accordingly.
    /// Will be populated during first run or by execution of sql on db.
    /// </summary>
    [Table("tbl_country_time_zones")]
    public class CountryEntity
    {
        /// <summary>
        /// Country Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Country Name.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// TimeZone shortcut.
        /// </summary>
        public string TimeZoneAbbreviation { get; set; }
        /// <summary>
        /// UTC Offset to tackle time zone difference.
        /// </summary>
        public string UtcOffset { get; set; }
    }
}
