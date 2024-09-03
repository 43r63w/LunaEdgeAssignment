using LunaTask.DAL.Entities;

namespace LunaTask.BLL.Jwt.Interfaces
{
    public interface IJwtGenerator
    {
        string GenerateToken(User user);
    }
}
