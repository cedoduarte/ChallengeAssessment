using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<ActionResult<CustomerViewModel>>
    {
        public int Id { get; set; }
    }
}
