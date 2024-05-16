using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<ActionResult<CustomerViewModel>>
    {
        public int Id { get; set; }
    }
}
