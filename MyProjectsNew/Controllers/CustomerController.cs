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
        /// Get the Customers id and Show it Here
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
        /// Get the CustomerName by name and Show it Here
        /// </summary>
        /// <returns>if succeed return CustomerName </returns>
        [HttpGet]
        [Route("getGoodsNameByName/{name}")]
        public async Task<ActionResult<List<CustomerName>>> GetCustomerNameByName(string name)
        {
            var CustomerName = await _db.CustomerName
                .Where(x => x.FirstName.Contains(name))
                .ToListAsync();

            return CustomerName;
        }
        /// <summary>
        /// Get the CustomerName by email and Show it Here
        /// </summary>
        /// <returns>if succeed return CustomerName </returns>
        [HttpGet]
        [Route("getGoodsNameByEmail/{email}")]
        public async Task<ActionResult<List<CustomerName>>> GetCustomerNameByEmail(string email)
        {
            var CustomerName = await _db.CustomerName
                .Where(x => x.Email.Contains(email))
                .ToListAsync();

            return CustomerName;
        }

        /// <summary>
        /// Get the CustomerName by name and email and Show it Here
        /// </summary>
        /// <returns>if succeed return CustomerName </returns>
        [HttpGet]
        [Route("getCustomerName")]
        public async Task<ActionResult<List<CustomerName>>> GetCustomerName(string? name,string? email)
        {
            var query = _db.CustomerName.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x =>
                    x.FirstName.Contains(name.Trim()));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(x =>
                    x.Email.Contains(email.Trim()));
            }

            var customerNames = await query.ToListAsync();

            return customerNames;
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
                Email = customerNameModel.Email,
                Type = customerNameModel.Type
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
            customer.Code = CustomerNameModel.Code;
            customer.FirstName = CustomerNameModel.FirstName;
            customer.LastName = CustomerNameModel.LastName;
            customer.Description = CustomerNameModel.Description;
            customer.Email = CustomerNameModel.Email;
            customer.Type = CustomerNameModel.Type;

            await _db.SaveChangesAsync();

            return Ok(customer);
        }
        /// <summary>
        /// Delete the Customers with Id and Show it Here
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
