using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveTypesVM
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type Name")]
        [Required(ErrorMessage ="Name is required")]  
        public string Name { get; set; }
        [Display(Name="Default number of Days")]
        [Required(ErrorMessage = "Default number of Days is required")]
        [Range(1,25,ErrorMessage ="Enter a valid number")]
        public int DefaultDays { get; set; }
    }
}
