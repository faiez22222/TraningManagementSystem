using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using LoginService.Controllers;
using LoginService.Model;
using LoginService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoginServiceUnitTesting
{
    [TestFixture]
    public class LoginControllerTest
    {
        private Mock<ILogin> _mockLoginRepo;
        private LoginController _controller;
        [SetUp]
        public void Setup()
        {
            _mockLoginRepo = new Mock<ILogin>();
            _controller = new LoginController(_mockLoginRepo.Object);
        }

        [Test]
        public async Task Login_ValidCredentials_ReturnsOkResult()
        {
            var loginmodel = new Login
            {
                username = "faiez",
                password = "hashedpassword123"
            };
            string valid = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJmYWlleiIsImp0aSI6IjY4OGM2MDIzLWZhMWUtNDAwYi04Yjc5LTY0ZThlM2ZkZTQ0MSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImpvaG4uZG9lQGV4YW1wbGUuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiTWFuYWdlciIsImV4cCI6MTcyMDg3OTIxMSwiaXNzIjoieW91cl9pc3N1ZXJfaGVyZSIsImF1ZCI6InlvdXJfaXNzdWVyX2hlcmUifQ.j7NCVxarW2qLYiC34VUYWThh4jBen50jmksCAKq89gg";            _mockLoginRepo.Setup(repo=>repo.LoginUser(loginmodel)).ReturnsAsync("");

            var result = await _controller.Login(loginmodel);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            var tokenString = okResult.Value.GetType().GetProperty("token");
            Assert.That(tokenString, Is.Not.Null);
        }
        [Test]
        public async Task Login_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var loginModel = new Login { username = "testuser", password = "wrongpassword" };
            _mockLoginRepo.Setup(repo => repo.LoginUser(loginModel)).ReturnsAsync((string)null);

            // Act
            var result = await _controller.Login(loginModel);

            // Assert
            Assert.That( result , Is.InstanceOf<UnauthorizedResult>() );
        }
    }
}
