using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.BLL.Dtos.Response
{
    public record ResponseDto(bool IsSuccsed,string Message,object? Data = null);
    
}
