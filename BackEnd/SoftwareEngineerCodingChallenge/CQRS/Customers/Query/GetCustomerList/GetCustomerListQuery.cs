using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<ActionResult<IEnumerable<CustomerViewModel>>>
    {
        public string Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}