namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// Add manager request
    /// </summary>
    public class ManagerRequest
    {
        /// <summary>
        /// Email id of new manager
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Chooosen password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Fuull name of the manager
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Phone number of the manager
        /// </summary>
        public string Phone { get; set; }
    }
}
