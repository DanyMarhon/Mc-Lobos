using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Customer;

namespace TPInvOp.Service.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<CustomerListDto> GetAll();
        CustomerEditDto? CustomerById(int id);
        bool Exist(Customer customer, int? excludeId = null);
        bool Save(CustomerEditDto customerDto, out List<string> errors);
        bool Remove(int customerId, out List<string> errors);
    }
}
