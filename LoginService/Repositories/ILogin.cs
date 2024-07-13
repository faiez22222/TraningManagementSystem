using LoginService.Model;
namespace LoginService.Repositories
{
    public interface ILogin
    {
        Task<string> LoginUser(Login login);
    }
}
