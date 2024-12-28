namespace KAMLMSContracts.ResponseModels
{
    /// <summary>
    /// Call Schedule Custom response
    /// </summary>
    public class CallScheduledResponse
    {
        /// <summary>
        /// Unique identifier for the scheduled call.
        /// </summary>
        public int CallScheduleId { get; set; }

        /// <summary>
        /// POC with whom the call is scheduled.
        /// </summary>
        public string ScheduledWithName { get; set; }

        /// <summary>
        /// Phone number of POC whom the call is scheduled.
        /// </summary>
        public string ScheduledWithPhone { get; set; }

        /// <summary>
        /// Name of the manager who is making the call.
        /// </summary>
        public string CallerName { get; set; }

        /// <summary>
        /// Date and time when the call is scheduled.
        /// </summary>
        public DateTime ScheduledAt { get; set; }

        /// <summary>
        /// Optional comments or additional information about the scheduled call.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Unique identifier for the status of the call.
        /// </summary>
        public int CallStatusId { get; set; }

        /// <summary>
        /// Name of the current status of the call (e.g., Scheduled, Completed).
        /// </summary>
        public string CallStatusName { get; set; }
    }
}
