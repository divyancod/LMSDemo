namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// Add new lead request
    /// </summary>
    public class LeadsRequest
    {
        /// <summary>
        /// Name of the parent enterprise or organization.
        /// </summary>
        public string ParentEnterpriseName { get; set; }

        /// <summary>
        /// Name of the company making the request.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Official email address of the company.
        /// </summary>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Physical address of the company.
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// Country where the company is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Time zone of the company's location.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Start of the company's working hours (e.g., 09:00).
        /// </summary>
        public string WorkingHourStart { get; set; }

        /// <summary>
        /// End of the company's working hours (e.g., 05:00).
        /// </summary>
        public string WorkingHourEnd { get; set; }

        /// <summary>
        /// Optional comments or additional information provided by the company.
        /// </summary>
        public string? Comment { get; set; }
    }

    /// <summary>
    /// Update any existing lead
    /// </summary>
    public class UpdateLead
    {
        /// <summary>
        /// Unique identifier of the lead to be updated.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// New status of the lead (e.g., active, inactive, closed).
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Comment or reason for the update.
        /// </summary>
        public string comment { get; set; }
    }

}
