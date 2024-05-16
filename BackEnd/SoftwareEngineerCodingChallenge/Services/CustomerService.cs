using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.CreateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.DeleteCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.UpdateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerById;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerList;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Services.Interface;

namespace SoftwareEngineerCodingChallenge.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<CustomerViewModel>> CreateCustomer(CreateCustomerCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<CustomerViewModel>> DeleteCustomer(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteCustomerCommand() 
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetAlumnoList(GetCustomerListQuery request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<CustomerViewModel>> GetCustomerById(int id)
        {
            try
            {
                return await _mediator.Send(new GetCustomerByIdQuery() 
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<CustomerViewModel>> UpdateCustomer(UpdateCustomerCommand request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
