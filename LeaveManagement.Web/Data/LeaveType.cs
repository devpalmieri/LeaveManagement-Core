namespace LeaveManagement.Web.Data
{
    public abstract class LeaveType: BaseIdentity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }    
    }
}
