using Moq;
using NUnit.Framework;
using LoginService.Repositories;
using LoginService.Model;
using LoginService.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LoginService.DataTransferObject;
using System;
using Microsoft.EntityFrameworkCore;

namespace LoginService.Tests
{
    public class LoginRepositoryTests
    {
        private LoginContext _context;
        private Mock<IUserValidationClient> _mockUserValidationClient;
        private Mock<IConfiguration> _mockConfiguration;
        private LoginRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LoginContext>()
                .UseInMemoryDatabase(databaseName: "Test2Database")
                .Options;

            // Mock LoginContext with valid DbContextOptions
             _context = new LoginContext(options);
            _mockUserValidationClient = new Mock<IUserValidationClient>();
            _mockConfiguration = new Mock<IConfiguration>();

            var jwtSettings = new Dictionary<string, string>
            {
                { "Jwt:Key", "test_key_12345678900000000000000000000000000000" },
                { "Jwt:Issuer", "test_issuer" }
            };
            _mockConfiguration.Setup(c => c.GetSection(It.IsAny<string>())).Returns((string key) =>
            {
                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(jwtSettings)
                    .Build();
                return config.GetSection(key);
            });

            _repository = new LoginRepository(_context, _mockUserValidationClient.Object, _mockConfiguration.Object);
        }

        [Test]
        public async Task LoginUser_ValidCredentials_ReturnsToken()
        {
            // Arrange
            var user = new User { Username = "testuser", Email = "test@example.com", Role = UserRole.Employee };
            _mockUserValidationClient.Setup(client => client.ValidateUser("testuser", "password")).ReturnsAsync(user);

            var loginModel = new Login { username = "testuser", password = "password" };

            // Act
            var token = await _repository.LoginUser(loginModel);

            // Assert
            Assert.That(token , Is.Not.Null);
        }

        [Test]
        public async Task LoginUser_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            _mockUserValidationClient.Setup(client => client.ValidateUser("testuser", "wrongpassword")).ReturnsAsync((User)null);

            var loginModel = new Login { username = "testuser", password = "wrongpassword" };

            // Act
            var token = await _repository.LoginUser(loginModel);

            // Assert
            Assert.That(token, Is.Null);
        }
        [TearDown]
        public void TearDown()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
