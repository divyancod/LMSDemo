
namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// Any update in the scheduled call
    /// </summary>
    public class UpdateCallScheduleRequest
    {
        /// <summary>
        /// unique call id of the scheduled call
        /// </summary>
        public string CallId { get; set; }
        /// <summary>
        /// Change the status to what?
        /// </summary>
        public string StatusId { get; set; }
        /// <summary>
        /// reason why call status is being changed
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// If call is getting reschuedled then next call is scheduled at?
        /// </summary>
        public string? ReScheduleDate { get; set; }
    }
}
