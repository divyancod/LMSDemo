namespace KAMLMSContracts.ResponseModels
{
    public class LeadInfoResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string EnterpriseName { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
