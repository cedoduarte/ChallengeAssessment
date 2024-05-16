using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, ActionResult<CustomerViewModel>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<CustomerViewModel>> Handle(GetCustomerByIdQuery request, CancellationToken cancel)
        {
            try
            {
                Customer selectedCustomer = await _dbContext.Customers
                    .Where(a => a.Id == request.Id)
                    .FirstOrDefaultAsync(cancel);
                if (selectedCustomer is null)
                {
                    throw new Exception($"The customer with ID {request.Id} does not exist!");
                }
                return _mapper.Map<CustomerViewModel>(selectedCustomer);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}