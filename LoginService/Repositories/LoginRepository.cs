using LoginService.Model;
using LoginService.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LoginService.DataTransferObject;

namespace LoginService.Repositories
{
    public class LoginRepository : ILogin
    {
        private LoginContext _context;
        private UserValidationClient _userValidationClient;
        private readonly IConfiguration _configuration;
        public LoginRepository(LoginContext context, UserValidationClient userValidationClient, IConfiguration configuration)
        {
            _context = context;
            _userValidationClient = userValidationClient;
            _configuration = configuration;
        }

        public async Task<string> LoginUser(Login login)
        {
            // Validate user
            User user = await _userValidationClient.ValidateUser(login.username, login.password);
            if (user == null)
            {
                return null; // Invalid credentials
            }

            // Ensure configuration is properly set up
            var jwtSection = _configuration.GetSection("Jwt");
            var key = jwtSection["Key"];
            var issuer = jwtSection["Issuer"];

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(issuer))
            {
                throw new InvalidOperationException("JWT configuration is missing.");
            }

            // Generate security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),  // Add user's email
                new Claim(ClaimTypes.Role, user.Role.ToString())     // Add user's role
            };

            // Create token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            // Save login details to the database
            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();

            // Return the generated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
