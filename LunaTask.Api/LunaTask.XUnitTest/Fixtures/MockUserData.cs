using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.User;
using LunaTask.BLL.Hasher;
using LunaTask.DAL.Entities;

namespace LunaTask.XUnitTest.Data
{
    public class MockUserData
    {

        public readonly static ResponseDto ResponseDto = new ResponseDto(true, "Successfully login, Id:3cce29ea-76f5-4bd2-aadb-3686db2b9fc3", "Token");


        public readonly static string MockToken = "Token";
        

        public readonly static User UserForMock = new User
        {
            Id = Guid.NewGuid(),
            Email = "test@gmail.com",
            Username = "Test",
            PasswordHash = HashPassword.Hash("12345!"),
        };

        public readonly static UserLoginDto UserLoginDto = new UserLoginDto("test@gmail.com", "Test", "12345!");



    }
}
