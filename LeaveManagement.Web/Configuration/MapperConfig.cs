using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using SQLitePCL;

namespace LeaveManagement.Web.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig() { 
            CreateMap<LeaveType,LeaveTypesVM>().ReverseMap();
            CreateMap<LeaveTypesVM, LeaveType>().ReverseMap();
        }   

    }
}
