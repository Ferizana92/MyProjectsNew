using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectsNew.Contracts;
using MyProjectsNew.Controllers;
using MyProjectsNew.Data;
using MyProjectsNew.Entities;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MyProjectsNew.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DataContext _db;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns>Constructor for CustomerController</returns>
        public CustomerController(DataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get the Customers Name and Show it Here
        /// </summary>
        /// <returns>if succeed return Customers names</returns>
        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<ActionResult<List<CustomerName>>> GetAllPersonnel()
        {

            var personnelname = await _db.CustomerName.ToListAsync();
            return Ok(personnelname);

        }

        /// <summary>
        /// Get the Customers Name and Show it Here
        /// </summary>
        /// <returns>if succeed return Customers names</returns>
        /// 
        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<CustomerName> GetCustomerById(int id)
        {
            var customer = await _db.CustomerName
                .Where(x => x.Code == id)
                .FirstOrDefaultAsync();

            return customer;
        }

        /// <summary>
        /// Post the Customers Name and save in db
        /// </summary>
        /// <returns>CreateCustomerName</returns>
        [HttpPost]
        [Route("CreateCustomerName")]
        public async Task<ActionResult<CustomerPersonnelNames>> CreateCustomerName([FromBody] CustomerPersonnelNames customerNameModel)
        {
            var command = new CustomerPersonnelNames

            {  
                Id = customerNameModel.Id,
                Code = customerNameModel.Code,
                FirstName = customerNameModel.FirstName,
                LastName = customerNameModel.LastName,
                Description = customerNameModel.Description,
                Email = customerNameModel.Email
            };

            _db.CustomerPersonnelNames.Add(command);
            await _db.SaveChangesAsync();

            return Ok(command);
        }

        /// <summary>
        /// Update the Customers Name and Show it Here
        /// </summary>
        /// <returns>UpdateCustomerName</returns>
        [HttpPut]
        [Route("UpdateCustomerName")]
        public async Task<ActionResult<CustomerPersonnelNames>> UpdateCustomerName([FromBody] CustomerPersonnelNames CustomerNameModel)
        {
            var customer = await _db.CustomerPersonnelNames
                .FirstOrDefaultAsync(x => x.Id == CustomerNameModel.Id);

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            customer.FirstName = CustomerNameModel.FirstName;
            customer.LastName = CustomerNameModel.LastName;
            customer.Description = CustomerNameModel.Description;
            customer.Email = CustomerNameModel.Email;

            await _db.SaveChangesAsync();

            return Ok(customer);
        }
        /// <summary>
        /// Delete the Customers Name and Show it Here
        /// </summary>
        /// <returns>DeleteCustomerName</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerName(int id)
        {
            var CustomerPersonnelNames = await _db.CustomerPersonnelNames.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (CustomerPersonnelNames == null)
                return NotFound();

            _db.CustomerPersonnelNames.Remove(CustomerPersonnelNames);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
