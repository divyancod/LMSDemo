using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    [Table("tbl_leads_information")]
    public class LeadsEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string ParentEnterpriseName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public string WorkingHourStart { get; set; }
        public string WorkingHourEnd { get; set; }

        public string? Comment { get; set; }

        public ManagersEntity AddedBy { get; set; }
        [ForeignKey("AddedBy")]
        public Guid? AddedById { get; set; }
        public ManagersEntity AssignedTo { get; set; }
        [ForeignKey("AssignedTo")]
        public Guid? AssignedToId { get; set; }

        public LeadStatusEntity status { get; set; }
        [ForeignKey("status")]
        public int StatusId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }

    [Table("tbl_status")]
    public class LeadStatusEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string Status { get; set; }
    }
}
