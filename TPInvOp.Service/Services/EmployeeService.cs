using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Employee;
using TPInvOp.Service.Interfaces;

namespace TPInvOp.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IQueryable<EmployeeListDto> GetAll()
        {
            var employeees = _unitOfWork.Employee.GetAll();
            return _mapper.ProjectTo<EmployeeListDto>(employeees);
        }

        public EmployeeEditDto? EmployeeById(int id)
        {
            var employee = _unitOfWork.Employee.Get(filter: l => l.EmployeeID == id,
                tracked: true);
            if (employee is null) return null;
            return _mapper.Map<EmployeeEditDto>(employee);
        }

        public bool Exist(Employee employee, int? excludeId = null)
        {
            return _unitOfWork.Employee.Exist(employee, excludeId);
        }

        public bool Save(EmployeeEditDto employeeDto, out List<string> errors)
        {
            errors = new List<string>();
            Employee employee = _mapper.Map<Employee>(employeeDto);
            if (employee.EmployeeID == 0)
            {
                if (!_unitOfWork.Employee.Exist(employee))
                {
                    _unitOfWork.Employee.Add(employee);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Employee Already Exist!!");
                    return false;
                }

            }
            else
            {
                if (!_unitOfWork.Employee.Exist(employee, employee.EmployeeID))
                {
                    _unitOfWork.Employee.Update(employee);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Employee Already Exist!!");
                    return false;
                }

            }
        }

        public bool Remove(int employeeId, out List<string> errors)
        {
            errors = new List<string>();
            var employee = _unitOfWork.Employee.Get(filter: l => l.EmployeeID == employeeId,
                tracked: true);
            if (employee is null)
            {
                errors.Add("Employee does not exist");
                return false;
            }
            _unitOfWork.Employee.Remove(employee);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
