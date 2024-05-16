using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Command.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ActionResult<CustomerViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<CustomerViewModel>> Handle(CreateCustomerCommand request, CancellationToken cancel)
        {
            try
            {
                ValidateInput(request);
                Customer newCustomer = new Customer()
                {
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    Email = request.Email.Trim()
                };
                await _dbContext.Customers.AddAsync(newCustomer, cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return _mapper.Map<CustomerViewModel>(newCustomer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateInput(CreateCustomerCommand request)
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
