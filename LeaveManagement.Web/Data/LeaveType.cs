using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Data
{
    public class LeaveType:BaseIdentity
    {
        //[Key]
        //public int Id { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime DateModified { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }    
    }
}
