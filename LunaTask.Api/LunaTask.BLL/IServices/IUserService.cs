using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.User;
using Microsoft.AspNetCore.Http;

namespace LunaTask.BLL.IServices
{
    public interface IUserService
    {
        Task<ResponseDto> Register(UserCreateDto userCreateDto);
        Task<ResponseDto> Login(UserLoginDto userLoginDto);
    }
}
