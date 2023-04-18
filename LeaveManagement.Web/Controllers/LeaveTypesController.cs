using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]

    public class LeaveTypesController : Controller
    {

        private readonly IMapper mapper;

        public ILeaveTypeRepository LeaveTypeRepository { get; set; }
        public ILeaveAllocationRepository LeaveAllocationRepository { get; set; }

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper)
        {
            this.LeaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
            this.LeaveAllocationRepository = leaveAllocationRepository;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = mapper.Map<IEnumerable<LeaveTypesVM>>(await LeaveTypeRepository.GetAllAsync());
              return leaveTypes != null ? 
                          View(leaveTypes) :
                          Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null )
            //{
            //    return NotFound();
            //}

            var leaveType = await LeaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTytpesVM = mapper.Map<LeaveTypesVM>(leaveType);
            return View(leaveTytpesVM);
        }

        // GET: LeaveTypes/Create
        //[Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create( LeaveTypesVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                DateTime date= DateTime.Now;    
                leaveType.DateCreated = date;   
                leaveType.DateModified = date;  
                await LeaveTypeRepository.AddAsync(leaveType);
               
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var leaveType = await LeaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTytpesVM=mapper.Map<LeaveTypesVM>(leaveType);  
            return View(leaveTytpesVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id,  LeaveTypesVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                    leaveType.DateModified = DateTime.Now;
                    await LeaveTypeRepository.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exist = await LeaveTypeExists(leaveTypeVM.Id);
                    if (!exist)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var leaveType = await LeaveTypeRepository.GetAsync(id.Value);
                
            if (leaveType == null)
            {
                return NotFound();
            }
            var leaveTytpesVM = mapper.Map<LeaveTypesVM>(leaveType);
            return View(leaveTytpesVM);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context.LeaveTypes == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            //}
            var leaveType = await LeaveTypeRepository.GetAsync(id);
            if (leaveType != null)
            {
                await   LeaveTypeRepository.DeleteAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await LeaveAllocationRepository.LeaveAllocation(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExists(int id)
        {
          return await  LeaveTypeRepository.Exists(id);    
        }
    }
}
