using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Models;

namespace SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerList
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, ActionResult<IEnumerable<CustomerViewModel>>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerListHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> Handle(GetCustomerListQuery request, CancellationToken cancel)
        {
            try
            {
                if (request.GetAll)
                {
                    return new OkObjectResult(
                        _mapper.Map<IEnumerable<CustomerViewModel>>(
                            await _dbContext.Customers.ToListAsync(cancel)));
                }
                if (string.IsNullOrEmpty(request.Keyword))
                {
                    throw new Exception("The keyword cannot be empty!");
                }
                string keyword = request.Keyword.ToLower().Trim();
                return new OkObjectResult(
                    _mapper.Map<IEnumerable<CustomerViewModel>>(
                        await _dbContext.Customers
                        .Where(c => c.FirstName.Contains(keyword)
                            || c.LastName.Contains(keyword)
                            || c.Email.Contains(keyword))
                        .ToListAsync(cancel)));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}