using LunaTask.BLL.Dtos.Response;
using LunaTask.BLL.Dtos.User;
using LunaTask.BLL.Hasher;
using LunaTask.BLL.IServices;
using LunaTask.BLL.Jwt.Interfaces;
using LunaTask.DAL.Entities;
using LunaTask.DAL.GenericRepository.Interfaces;

namespace LunaTask.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtGenerator _jwtGenerator;

        public UserService(IUserRepository userRepository,
            IJwtGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
        }

        public async System.Threading.Tasks.Task<ResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {


            if (string.IsNullOrWhiteSpace(userLoginDto.Email) |
                string.IsNullOrWhiteSpace(userLoginDto.Username) |
                string.IsNullOrWhiteSpace(userLoginDto.Password))
            {
                return new ResponseDto(false, "Email,username and password must be filled");
            }


            var userFromDb = await _userRepository.GetAsync(e => e.Email == userLoginDto.Email);

            if (userFromDb == null)
                return new ResponseDto(false, "User not found");

            var isPasswordValid = HashPassword.CheckPasswordHash(userLoginDto.Password, userFromDb.PasswordHash);

            string result = "";

            if (isPasswordValid)
                result = _jwtGenerator.GenerateToken(userFromDb);


            if (string.IsNullOrWhiteSpace(result))
                return new ResponseDto(false, "Something wrong");

            return new ResponseDto(true, $"Successfully login, Id:{userFromDb.Id}", result);


        }

        public async System.Threading.Tasks.Task<ResponseDto> RegisterAsync(UserCreateDto userCreateDto)
        {
            if (string.IsNullOrWhiteSpace(userCreateDto.Email) |
                string.IsNullOrWhiteSpace(userCreateDto.Username) |
                string.IsNullOrWhiteSpace(userCreateDto.Passsword))
            {
                return new ResponseDto(false, "Email,username and password must be filled");
            }

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = userCreateDto.Email,
                Username = userCreateDto.Username,
                PasswordHash = HashPassword.Hash(userCreateDto.Passsword),
            };

            _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();


            var result = await _userRepository.GetAsync(e => e.Email == userCreateDto.Email);

            if (result == null)
                return new ResponseDto(false, "Something wrong");

            return new ResponseDto(true, "Successfully register");
        }
    }
}
