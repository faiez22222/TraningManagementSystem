namespace LoginService.DataTransferObject
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Manager,
        Administrator,
        Employee
    }
}
