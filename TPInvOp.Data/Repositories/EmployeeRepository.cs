using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Exist(Employee employee, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Employees.Any(e => e.EmployeeName.ToUpper() == employee.EmployeeName.ToUpper()
                                && e.EmployeeID != excludeId)
                : _dbContext.Employees.Any(e => e.EmployeeName.ToUpper() == employee.EmployeeName.ToUpper());
        }
        public void Update(Employee employee)
        {
            var employeeInDb = Get(filter: p => p.EmployeeID == employee.EmployeeID,
                tracked: true);
            if (employeeInDb != null)
            {
                employeeInDb.EmployeeName = employee.EmployeeName;
                employeeInDb.Position = employee.Position;


                _dbContext.Entry(employeeInDb).State = EntityState.Modified;
            }
        }
    }
}
