using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{
    public class LeaveAllocation: BaseIdentity
    {
        public int NumeberOfDays { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }    
        public int LeaveTypeId { get; set; }  
        public string EmployeeId { get; set; }
    }
}
