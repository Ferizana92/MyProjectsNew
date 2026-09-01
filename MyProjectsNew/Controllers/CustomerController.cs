using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectsNew.Contracts;
using MyProjectsNew.Data;
using MyProjectsNew.Entities;
using System.ComponentModel.DataAnnotations;

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
        /// Post the Customers Name and Show it Here
        /// </summary>
        /// <returns>CreateCustomerName</returns>
        [HttpPost]
        [Route("CreateCustomerName")]

        public async Task<ActionResult<List<CustomerPersonnelNames>>> CreateCustomerName([FromBody] CustomerPersonnelNames CustomerNameModel)
        {
            var command = new CustomerPersonnelNames
            {
                FirstName = CustomerNameModel.FirstName,
                LastName = CustomerNameModel.LastName,
                Description = CustomerNameModel.Description,
                Email = CustomerNameModel.Email
            };
            await _db.AddRangeAsync();
            return Ok(command);


        }
        /// <summary>
        /// Update the Customers Name and Show it Here
        /// </summary>
        /// <returns>UpdateCustomerName</returns>
        [HttpPut]
        [Route("UpdateCustomerName")]
        public async Task<ActionResult<List<CustomerPersonnelNames>>> UpdateCustomerName([FromBody] CustomerPersonnelNames CustomerNameModel)
        {
            var command = new CustomerPersonnelNames
            {
                FirstName = CustomerNameModel.FirstName,
                LastName = CustomerNameModel.LastName,
                Description = CustomerNameModel.Description,
                Email = CustomerNameModel.Email
            };
            await _db.AddAsync(command);
            return Ok(command);

        }
        /// <summary>
        /// Delete the Customers Name and Show it Here
        /// </summary>
        /// <returns>DeleteCustomerName</returns>
        [HttpDelete]
        public async Task<ActionResult<List<CustomerPersonnelNames>>> DeleteCustomerName([FromRoute][Required] long id) //yani chi Required?
        {
            var deleteCommand = new DeleteCustomerGroupCommand { Id = id };
           
            return Ok(deleteCommand);
        }
    }
}
