using AutoMapper;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;

namespace ToDoListAPI.MapperConfig
{
    public class ToDoListMapperConfig: Profile
    {
        public ToDoListMapperConfig()
        {
            CreateMap<AddTaskDTO,TaskManagment >().AfterMap(
                (src,dest) =>
            {
                dest.status = false;
                dest.creationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            } 
            ).ReverseMap();
            
            //CreateMap<EditTaskDTO, TaskManagment>().ForMember(dest => dest.Id, op => op.Ignore()).AfterMap((src,dest) => 
            // dest.creationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ReverseMap();
            CreateMap<EditTaskDTO, TaskManagment>().ReverseMap();

            CreateMap<TaskManagment, SelectTaskDTO >().ReverseMap();

        }
    }
}
