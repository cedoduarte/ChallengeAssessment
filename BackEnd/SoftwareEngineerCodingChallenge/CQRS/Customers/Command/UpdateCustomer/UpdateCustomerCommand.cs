using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Command.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<ActionResult<CustomerViewModel>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
