using Microsoft.EntityFrameworkCore;
using LoginService.Model;

namespace LoginService
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options) { }
        public DbSet<Login> Logins { get; set; }    
    }
}
