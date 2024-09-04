using LunaTask.DAL.Enums;

namespace LunaTask.BLL.Dtos.Task
{
    public record TaskDto(
        string Id,
        string Title,
        string Description,
        DateTime DueData,
        Status Status,
        Priority Priority,
        string UserId    
    );

}
