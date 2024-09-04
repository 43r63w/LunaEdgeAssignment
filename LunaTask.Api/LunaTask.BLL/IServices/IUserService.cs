using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.User;
using Microsoft.AspNetCore.Http;

namespace LunaTask.BLL.IServices
{
    public interface IUserService
    {
        Task<ResponseDto> RegisterAsync(UserCreateDto userCreateDto);
        Task<ResponseDto> LoginAsync(UserLoginDto userLoginDto);
    }
}
