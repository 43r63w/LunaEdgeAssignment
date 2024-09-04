using AutoMapper;
using LunaTask.BLL.Dtos.Task;
using LunaTask.BLL.Dtos.User;
using LunaTask.DAL.Entities;

namespace LunaTask.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();


            CreateMap<TaskDto, LunaTask.DAL.Entities.Task>().ReverseMap();

        }
    }
}
