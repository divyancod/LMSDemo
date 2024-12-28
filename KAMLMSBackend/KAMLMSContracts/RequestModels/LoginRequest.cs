namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// Primary for login purpose
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Email id for login
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password for which login is initated
        /// </summary>
        public string Password { get; set; }
    }
}
