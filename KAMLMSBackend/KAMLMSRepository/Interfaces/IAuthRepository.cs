using KAMLMSContracts.Entities;

namespace KAMLMSRepository.Interfaces
{
    /// <summary>
    /// Authorization repository for authentication related queries
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Add a new user to platform
        /// </summary>
        /// <param name="entity">Details of the user which needs to be created</param>
        void AddUser(LoginEntity entity);
        /// <summary>
        /// Return the user based on the email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User details to process further by email id</returns>
        LoginEntity GetUser(string email);
    }
}
