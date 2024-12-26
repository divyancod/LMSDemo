
namespace KAMLMSContracts.ResponseModels
{
    public class FollowUpResponse
    {
        public int id { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string FollowupDate { get; set; }
    }
}
