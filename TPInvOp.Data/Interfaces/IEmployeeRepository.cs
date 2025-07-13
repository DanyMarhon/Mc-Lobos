using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        bool Exist(Employee employee, int? excludeId = null);
        void Update(Employee employee);
    }
}
