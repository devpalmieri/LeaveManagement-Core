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

            CreateMap<EmployeeListVM, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeListVM>().ReverseMap();

            CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();

            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>().ReverseMap();

            //CreateMap<LeaveRequest, LeaveRequestCreateVM>().ReverseMap();
            //CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
        }   


    }
}
