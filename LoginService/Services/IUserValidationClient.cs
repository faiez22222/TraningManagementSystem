using LoginService.DataTransferObject;
namespace LoginService.Services
{
    public interface IUserValidationClient
    {
        Task<User> ValidateUser(string username, string password);
    }
}
