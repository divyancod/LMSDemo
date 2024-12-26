
namespace KAMLMSContracts.RequestModels
{
    public class UpdateCallScheduleRequest
    {
        public string CallId { get; set; }
        public string StatusId { get; set; }
        public string? Comment { get; set; }
        public string? ReScheduleDate { get; set; }
    }
}
