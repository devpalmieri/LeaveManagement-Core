﻿using AutoMapper.QueryableExtensions;
using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    { 
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly ApplicationDbContext context;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager, 
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper,
            IEmailSender emailSender,
            AutoMapper.IConfigurationProvider configurationProvider) : base(context)
        {
            this.userManager= userManager;  
            this.leaveTypeRepository= leaveTypeRepository;
            this.context= context;
            this.mapper= mapper;
            this.emailSender = emailSender;
            this.configurationProvider = configurationProvider;
        }

        //public async Task LeaveAllocation(int leaveTypeId)
        //{
        //    var employees = await userManager.GetUsersInRoleAsync(Roles.User);
        //    var period = DateTime.Now.Year;
        //    var leaveType=await leaveTypeRepository.GetAsync(leaveTypeId);
        //    var allocations = new List<LeaveAllocation>();
        //    foreach (var employee in employees)
        //    {
        //        if (await AllocationExists(employee.Id, leaveTypeId, period))
        //            continue;

        //            allocations.Add (new LeaveAllocation
        //        {
        //            EmployeeId = employee.Id,
        //            LeaveTypeId = leaveTypeId,
        //            Period = period,
        //            NumeberOfDays = leaveType.DefaultDays
        //        });
        //        await AddRangeAsync (allocations);    
        //    }
        //}
        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
                                                                && q.LeaveTypeId == leaveTypeId
                                                                && q.Period == period);
        }
        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            var allocations = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId)
                //.ProjectTo<LeaveAllocationVM>(configurationProvider)
            .ToListAsync();

            var employee = await userManager.FindByIdAsync(employeeId);

            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);
            //employeeAllocationModel.LeaveAllocations = allocations;

            employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            var allocation = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                //.ProjectTo<LeaveAllocationEditVM>(configurationProvider);
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);

            var model = mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(allocation.EmployeeId));

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();
            var employeesWithNewAllocations = new List<Employee>();

            foreach (var employee in employees)
            {
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue;

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumeberOfDays = leaveType.DefaultDays
                });
                employeesWithNewAllocations.Add(employee);
            }

            await AddRangeAsync(allocations);

            foreach (var employee in employeesWithNewAllocations)
            {
                await emailSender.SendEmailAsync(employee.Email, $"Leave Allocation Posted for {period}", $"Your {leaveType.Name} " +
                    $"has been posted for the period of {period}. You have been given {leaveType.DefaultDays}.");
            }
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumeberOfDays = model.NumeberOfDays;
            await UpdateAsync(leaveAllocation);

            var user = await userManager.FindByIdAsync(leaveAllocation.EmployeeId);

            await emailSender.SendEmailAsync(user.Email, $"Leave Allocation Updated for {leaveAllocation.Period}",
                "Please review your leave allocations.");

            return true;
        }
        
        public async Task<LeaveAllocation> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            return await context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
