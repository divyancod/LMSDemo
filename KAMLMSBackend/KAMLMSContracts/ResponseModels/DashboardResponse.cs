using KAMLMSContracts.Entities;

namespace KAMLMSContracts.ResponseModels
{
    public class DashboardResponse
    {
        public string CompanyName { get; set; }
        public string ParentEnterpriseName { get; set; }
        public int StatusId { get; set; }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
    }
    public class DashboardResponseWithType
    {
       public IList<DashboardResponseWithLeads> data { get; set; }
        public DashboardResponseWithType()
        {
            data = new List<DashboardResponseWithLeads>();
        }
    }
    public class DashboardResponseWithLeads
    {
        public int id { get; set; }
        public string Status { get; set; }
        public IList<LeadInfoResponse> leads { get; set; }
    }
}
