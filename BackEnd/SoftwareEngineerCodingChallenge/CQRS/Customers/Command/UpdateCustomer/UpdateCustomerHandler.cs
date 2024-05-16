using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Command.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, ActionResult<CustomerViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<CustomerViewModel>> Handle(UpdateCustomerCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Customer selectedCustomer = await _dbContext.Customers
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedCustomer is null)
                {
                    throw new Exception($"The customer with ID {request.Id} does not exist!");
                }
                selectedCustomer.FirstName = request.FirstName.Trim();
                selectedCustomer.LastName = request.LastName.Trim();
                selectedCustomer.Email = request.Email.Trim();
                selectedCustomer.LastUpdatedDateTime = DateTime.Now;
                _dbContext.Customers.Update(selectedCustomer);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<CustomerViewModel>(selectedCustomer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(UpdateCustomerCommand request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                throw new Exception("The first name cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new Exception("The last name cannot be empty!");
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("The email cannot be empty!");
            }
        }
    }
}