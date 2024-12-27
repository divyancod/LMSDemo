namespace KAMLMSContracts.RequestModels
{
    public class LeadsRequest
    {
        public string ParentEnterpriseName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyAddress { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public string WorkingHourStart { get; set; }
        public string WorkingHourEnd { get; set; }

        public string? Comment { get; set; }
    }

    public class UpdateLead
    {
        public string id { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
    }
}
