using LunaTask.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace LunaTask.BLL.Dtos.Task
{
    public record TaskUpdateDto(
        [Required] string Title,
        string Description,
        DateTime DueData,
        Status Status,
        Priority Priority
    );

}