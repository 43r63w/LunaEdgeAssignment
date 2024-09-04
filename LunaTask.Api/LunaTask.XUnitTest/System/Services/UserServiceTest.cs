using FluentAssertions;
using LunaTask.BLL.Implementations;
using LunaTask.BLL.Jwt.Interfaces;
using LunaTask.DAL.Entities;
using LunaTask.DAL.GenericRepository.Interfaces;
using LunaTask.DAL.IGenericRepository.Interfaces;
using LunaTask.XUnitTest.Data;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq.Expressions;
using Task = System.Threading.Tasks.Task;

namespace LunaTask.XUnitTest.System.Services
{

    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userMockRepository;
        private readonly Mock<IJwtGenerator> _jwtGeneratorMock;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userMockRepository = new Mock<IUserRepository>();
            _jwtGeneratorMock = new Mock<IJwtGenerator>();
            _userService = new UserService(_userMockRepository.Object, _jwtGeneratorMock.Object);
        }

        [Fact]
        public async Task OnSuccess_LoginAsync_ShoudGivenToken()
        {
            _userMockRepository.Setup(service => service.GetAsync(It.IsAny<Expression<Func<User, bool>>>(),
                 It.IsAny<string>()))
                .ReturnsAsync(MockUserData.UserForMock);

            _jwtGeneratorMock.Setup(service => service.GenerateToken(It.IsAny<User>()))
                .Returns(MockUserData.MockToken);

            var result = await _userService.LoginAsync(MockUserData.UserLoginDto);

            result.Should().NotBeNull();
            result.Should().Be(MockUserData.ResponseDto);

            _jwtGeneratorMock.Verify(fn => fn.GenerateToken(It.IsAny<User>()), Times.Once);
        }
    }









}

