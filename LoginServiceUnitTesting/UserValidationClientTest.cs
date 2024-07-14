using LoginService.DataTransferObject;
using LoginService.Model;
using LoginService.Services;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoginServiceUnitTesting
{
    public class UserValidationClientTests
    {
        private Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private IUserValidationClient _userValidationClient;

        [SetUp]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://localhost:5062")
            };
            _userValidationClient = new UserValidationClient(httpClient);
        }

        [Test]
        public async Task ValidateUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var expectedUser = new User
            {
                UserID = 1,
                Username = "testuser",
                Email = "test@example.com",
                Role = UserRole.Employee
            };

            var responseContent = JsonConvert.SerializeObject(expectedUser);
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseContent, Encoding.UTF8, "application/json")
                });

            // Act
            var result = await _userValidationClient.ValidateUser("testuser", "password");

            // Assert
            Assert.That(result , Is.Not.Null);
            Assert.That(result.Username, Is.EqualTo(expectedUser.Username));
        }

        [Test]
        public async Task ValidateUser_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized
                });

            // Act
            var result = await _userValidationClient.ValidateUser("testuser", "wrongpassword");

            // Assert
            Assert.That(result , Is.Null);
        }
    }
}
