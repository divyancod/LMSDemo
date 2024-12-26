using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAMLMSContracts.Entities
{
    [Table("tbl_call_schedule_history")]
    public class CallScheduleEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CallScheduleId { get; set; }

        public LeadsEntity ScheduledFor { get; set; }
        [ForeignKey("ScheduledFor")]
        public Guid ScheduledForId { get; set; }

        public ContactEntity ScheduledWith { get; set; }
        [ForeignKey("ScheduledWith")]
        public Guid ScheduledWithId { get; set; }

        [ForeignKey("ScheduledBy")]
        public Guid ScheduledById { get; set; }
        public ManagersEntity ScheduledBy { get; set; }

        [ForeignKey("Caller")]
        public Guid CallerId { get; set; }
        public ManagersEntity Caller { get; set; }

        public DateTime ScheduledAt { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CallStatus")]
        public int CallStatusId { get; set; }
        public CallStatusEntity CallStatus { get; set; }
    }

    [Table("tbl_call_logs")]
    public class CallLogsEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("CallSchedule")]
        public int CallScheduleId { get; set; }
        public CallScheduleEntity CallSchedule { get; set; }

        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    [Table("tbl_call_status")]
    public class CallStatusEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
