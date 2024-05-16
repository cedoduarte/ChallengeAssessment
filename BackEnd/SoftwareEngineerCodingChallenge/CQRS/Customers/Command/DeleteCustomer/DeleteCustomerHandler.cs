using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Command.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, ActionResult<CustomerViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ActionResult<CustomerViewModel>> Handle(DeleteCustomerCommand request, CancellationToken cancel)
        {
            try
            {
                Customer existingCustomer = await _dbContext.Customers
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (existingCustomer is not null)
                {
                    _dbContext.Customers.Remove(existingCustomer);
                    await _dbContext.SaveChangesAsync(cancel);
                    return _mapper.Map<CustomerViewModel>(existingCustomer);
                }
                throw new Exception($"The customer with ID {request.Id} does not exist!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}