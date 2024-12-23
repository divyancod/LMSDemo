using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KAMLMSContracts.Entities
{
    public class LeadsEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ResturantId { get; set; }
        public string ResturantName { get; set; }
        public string ResturantAddress { get; set; }
        public string? Comment { get; set; }

        public ManagersEntity AddedBy { get; set; }
        [ForeignKey("AddedBy")]
        public Guid? AddedById { get; set; }
        public ManagersEntity AssignedTo { get; set; }
        [ForeignKey("AssignedTo")]
        public Guid? AssignedToId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
