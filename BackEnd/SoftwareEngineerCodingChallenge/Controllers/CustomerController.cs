using Microsoft.AspNetCore.Mvc;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.CreateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Command.UpdateCustomer;
using SoftwareEngineerCodingChallenge.CQRS.Customers.Query.GetCustomerList;
using SoftwareEngineerCodingChallenge.CQRS.Customers.ViewModel;
using SoftwareEngineerCodingChallenge.Services.Interface;

namespace SoftwareEngineerCodingChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CustomerViewModel>> CreateAlumno([FromBody] CreateCustomerCommand request)
        {
            try
            {
                return await _customerService.CreateCustomer(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<CustomerViewModel>> UpdateAlumno([FromBody] UpdateCustomerCommand request)
        {
            try
            {
                return await _customerService.UpdateCustomer(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CustomerViewModel>> DeleteAlumno([FromRoute] int id)
        {
            try
            {
                return await _customerService.DeleteCustomer(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetAlumnoById([FromRoute] int id)
        {
            try
            {
                return await _customerService.GetCustomerById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("get-list")]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetAlumnoList([FromQuery] GetCustomerListQuery request)
        {
            try
            {
                return await _customerService.GetAlumnoList(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}