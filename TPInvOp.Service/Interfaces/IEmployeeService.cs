using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Employee;

namespace TPInvOp.Service.Interfaces
{
    public interface IEmployeeService
    {
        IQueryable<EmployeeListDto> GetAll();
        EmployeeEditDto? EmployeeById(int id);
        bool Exist(Employee employee, int? excludeId = null);
        bool Save(EmployeeEditDto employeeDto, out List<string> errors);
        bool Remove(int employeeId, out List<string> errors);
    }
}
