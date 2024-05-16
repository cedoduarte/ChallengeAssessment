using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.CreateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.UpdateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerList;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;

namespace SoftwareEngineerCodingChallenge.Services.Interface
{
    public interface ICustomerService
    {
        Task<ActionResult<CustomerViewModel>> CreateCustomer(CreateCustomerCommand request);
        Task<ActionResult<CustomerViewModel>> UpdateCustomer(UpdateCustomerCommand request);
        Task<ActionResult<CustomerViewModel>> DeleteCustomer(int id);
        Task<ActionResult<CustomerViewModel>> GetCustomerById(int id);
        Task<ActionResult<IEnumerable<CustomerViewModel>>> GetAlumnoList(GetCustomerListQuery request);
    }
}
