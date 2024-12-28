using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    /// <summary>
    /// Primary table to store leads information
    /// </summary>
    [Table("tbl_leads_information")]
    public class LeadsEntity
    {
        /// <summary>
        /// Unique lead id for each lead
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Company Parent enterprise name as servral company have parent enterpise which have muliple child companies.
        /// Like Alphabet is of Google
        /// </summary>
        public string ParentEnterpriseName { get; set; }
        /// <summary>
        /// Exact company name.
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company default emailing address.
        /// </summary>
        public string CompanyEmail { get; set; }
        /// <summary>
        /// Location of company
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// Company country. Not referenced from the country as table. directly saving company country.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Timezone as country not allowed to select timezone. can be made flexible.
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Company working hours start time as we can't schedule call at any time.
        /// </summary>
        public string WorkingHourStart { get; set; }
        /// <summary>
        /// Company working hours end time as we can't schedule call at any time.
        /// </summary>
        public string WorkingHourEnd { get; set; }
        /// <summary>
        /// Any specific comment about company (eg - This company is looking for product xyz which we offer.)
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// Manager who is adding this lead
        /// </summary>
        public ManagersEntity AddedBy { get; set; }
        /// <summary>
        /// Managers unique key for reference.
        /// </summary>
        [ForeignKey("AddedBy")]
        public Guid? AddedById { get; set; }
        /// <summary>
        /// Who is going to handle this lead.
        /// </summary>
        public ManagersEntity AssignedTo { get; set; }
        /// <summary>
        /// Manager unqe key who is going to handle this lead
        /// </summary>
        [ForeignKey("AssignedTo")]
        public Guid? AssignedToId { get; set; }
        /// <summary>
        /// What is the current status of the lead from LeadStatusENUM
        /// </summary>
        public LeadStatusEntity status { get; set; }
        /// <summary>
        /// Id of the lead status
        /// </summary>
        [ForeignKey("status")]
        public int StatusId { get; set; }
        /// <summary>
        /// Datetime of creation of the lead.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// At what time this lead is getting modified.
        /// </summary>
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Lead status as we are storing status as foregin key in leads table.
    /// </summary>
    [Table("tbl_status")]
    public class LeadStatusEntity
    {
        /// <summary>
        /// Status unique ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Leads status exact string. from LeadStatusENUM (eg- New, In progress, ClosedWon, ClosedLost)
        /// </summary>
        public string Status { get; set; }
    }
}
