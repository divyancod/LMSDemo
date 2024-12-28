using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAMLMSContracts.Entities
{
    [Table("tbl_call_schedule_history")]
    public class CallScheduleEntity
    {
        /// <summary>
        /// Unique identifier for the call schedule record.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CallScheduleId { get; set; }

        /// <summary>
        /// Entity containing details of the lead for which the call is being scheduled.
        /// </summary>
        public LeadsEntity ScheduledFor { get; set; }

        /// <summary>
        /// Unique identifier for the lead associated with this call schedule.
        /// </summary>
        [ForeignKey("ScheduledFor")]
        public Guid ScheduledForId { get; set; }

        /// <summary>
        /// Entity containing the point-of-contact details for the lead.
        /// </summary>
        public ContactEntity ScheduledWith { get; set; }

        /// <summary>
        /// Unique identifier for the point-of-contact with whom the call is scheduled.
        /// </summary>
        [ForeignKey("ScheduledWith")]
        public Guid ScheduledWithId { get; set; }

        /// <summary>
        /// Unique identifier of the manager who scheduled the call.
        /// </summary>
        [ForeignKey("ScheduledBy")]
        public Guid ScheduledById { get; set; }

        /// <summary>
        /// Entity representing the manager who scheduled the call.
        /// </summary>
        public ManagersEntity ScheduledBy { get; set; }

        /// <summary>
        /// Unique identifier of the manager assigned to make the call.
        /// </summary>
        [ForeignKey("Caller")]
        public Guid CallerId { get; set; }

        /// <summary>
        /// Entity representing the manager assigned to make the call.
        /// </summary>
        public ManagersEntity Caller { get; set; }

        /// <summary>
        /// The date and time when the call is scheduled to take place.
        /// </summary>
        public DateTime ScheduledAt { get; set; }

        /// <summary>
        /// Optional comments or additional information about the call schedule.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// The date and time when this call schedule record was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Identifier for the status of the call.
        /// </summary>
        [ForeignKey("CallStatus")]
        public int CallStatusId { get; set; }

        /// <summary>
        /// Entity representing the status of the call (e.g., scheduled, completed, canceled).
        /// </summary>
        public CallStatusEntity CallStatus { get; set; }
    }


    //[Table("tbl_call_logs")]
    //public class CallLogsEntity
    //{
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    [Key]
    //    public int Id { get; set; }

    //    [ForeignKey("CallSchedule")]
    //    public int CallScheduleId { get; set; }
    //    public CallScheduleEntity CallSchedule { get; set; }

    //    public string Comment { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //}

    [Table("tbl_call_status")]
    public class CallStatusEntity
    {
        /// <summary>
        /// Unique identifier for the call status record.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Status of the call (e.g., Scheduled, Completed, Canceled) from CallStatusEnum Enum.
        /// </summary>
        public string Status { get; set; }
    }

}
