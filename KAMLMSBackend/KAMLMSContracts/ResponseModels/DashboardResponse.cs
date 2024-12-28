namespace KAMLMSContracts.ResponseModels
{
    /// <summary>
    /// This response is used for the stored procedure output related to the dashboard.
    /// </summary>
    public class DashboardResponse
    {
        /// <summary>
        /// Name of the company associated with the response.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Name of the parent enterprise for the company.
        /// </summary>
        public string ParentEnterpriseName { get; set; }

        /// <summary>
        /// Identifier for the status of the entity.
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Unique identifier for the entity.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Full name of the individual or entity associated with the response.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Status description for the entity.
        /// </summary>
        public string Status { get; set; }
    }

    /// <summary>
    /// Contains dashboard details and groups multiple lead types with related information in a single response.
    /// </summary>
    public class DashboardResponseWithType
    {
        /// <summary>
        /// Collection of lead types and their associated lead information.
        /// </summary>
        public IList<DashboardResponseWithLeads> data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardResponseWithType"/> class.
        /// </summary>
        public DashboardResponseWithType()
        {
            data = new List<DashboardResponseWithLeads>();
        }
    }

    /// <summary>
    /// Represents a lead type along with its associated lead information for display on the dashboard.
    /// </summary>
    public class DashboardResponseWithLeads
    {
        /// <summary>
        /// Identifier for the lead type.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Status description of the lead type.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Collection of leads associated with this lead type.
        /// </summary>
        public IList<LeadInfoResponse> leads { get; set; }
    }

}
