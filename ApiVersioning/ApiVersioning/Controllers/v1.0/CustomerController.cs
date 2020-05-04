using System;
using System.Collections.Generic;
using ApiVersioning.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers.v1._0
{
    [Route("api/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Test 1",
                    Phone = "(234) 456-3455",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            Id = 1,
                            OrderNumber = 123,
                            OrderDate = DateTime.Today
                        }
                    }
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
