using System.Collections.Generic;
using Business.v2.Customers.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models.v2;

namespace ApiVersioning.Controllers.v3
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("3")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customerRepository.GetCustomers());
        }
    }
}