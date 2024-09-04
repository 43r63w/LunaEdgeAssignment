using LunaTask.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace LunaTask.BLL.Dtos.Task
{

    public record TaskCreateDto(
        [Required] string Title,
        string Description,
        Guid UserId,
        Status? Status = null,        
        Priority? Priority = null,
        DateTime? DueDate = null
    );

   
}
