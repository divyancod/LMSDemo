namespace KAMLMSContracts.ResponseModels
{
    public class CallScheduledResponse
    {
        public int CallScheduleId { get; set; }
        public string ScheduledWithName { get; set; }
        public string ScheduledWithPhone { get; set; }
        public string CallerName { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string? Comment { get; set; }
        public int CallStatusId { get; set; }
        public string CallStatusName { get; set; }
    }

}
