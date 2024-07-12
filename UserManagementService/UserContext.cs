using Microsoft.EntityFrameworkCore;
using UserManagementService.Model;
namespace UserManagementService
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options) { } 
        public DbSet<User> Users { get; set; } 
    }
}
