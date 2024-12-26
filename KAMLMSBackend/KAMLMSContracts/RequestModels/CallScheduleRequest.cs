namespace KAMLMSContracts.RequestModels
{
    public class CallScheduleRequest
    {
        public string CompanyId { get; set; }
        public string PocId { get; set; }
        public string Time { get; set; }
        public string? Comment { get; set; }
    }
    public class CallFilters
    {
        public string[]? statusList { get; set; }
    }
}
