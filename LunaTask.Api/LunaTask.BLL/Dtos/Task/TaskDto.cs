using LunaTask.BLL.Dtos.User;
using LunaTask.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.BLL.Dtos.Task
{
    public record TaskDto(
        string Title,
        string Description,
        DateTime DueData,
        Status Status,
        Priority Priority,
        string UserId    
    );

}
