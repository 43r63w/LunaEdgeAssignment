
using LunaTask.BLL.Attribute;
using System.ComponentModel.DataAnnotations;


namespace LunaTask.BLL.Dtos.User
{
    public record UserCreateDto(
        [Required][EmailAddress] string Email,
        [Required] string Username, 
        [Required][MinLength(6),MaxLength(15)][Password] string Passsword
    );
}
 