using System.ComponentModel;

namespace TPInvOp.Web.ViewModels.Employee
{
    public class EmployeeEditVm
    {
        public int EmployeeId { get; set; }

        [DisplayName("Employee Name")]
        public string? EmployeeName { get; set; }
        public string? Position { get; set; }
    }
}
