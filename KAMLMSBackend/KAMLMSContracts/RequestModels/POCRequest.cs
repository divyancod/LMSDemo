namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// Add new POC request model
    /// </summary>
    public class POCRequest
    {
        /// <summary>
        /// Company id for which POC is being added
        /// </summary>
        public Guid CompanyId { get; set; }
        /// <summary>
        /// name of the poc.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Poc phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Poc email address.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// POC role in the company
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// If poc have a custom role (which is not in our DB)
        /// </summary>
        public string? CustomRole { get; set; }
        /// <summary>
        /// Should backend schedule call with this poc?
        /// </summary>
        public bool? IsMainPOC { get; set; }
        /// <summary>
        /// If backend to schuedle call while creating the poc at what time call needs to be scheduled
        /// </summary>
        public string? Time { get; set; }
    }
}
