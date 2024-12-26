using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAMLMSContracts.Entities
{
    [Table("tbl_country_time_zones")]
    public class CountryEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string TimeZoneAbbreviation { get; set; }
        public string UtcOffset { get; set; }
    }
}
