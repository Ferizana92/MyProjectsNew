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

        public CustomerController(DataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get the Customers Name and Show it Here
        /// </summary>
        /// <returns>if succeed return Customers names</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<CustomerName>>> GetAllPersonnel()
        {

            var personnelname = await _db.CustomerName.ToListAsync();
            return Ok(personnelname);

        }


        [HttpPost]
        [Route("{id}")]

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
        [HttpPut]
        [Route("{id}")]
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

        [HttpDelete]
        public async Task<ActionResult<List<CustomerPersonnelNames>>> DeleteCustomerName([FromRoute][Required] long id) //yani chi Required?
        {
            var deleteCommand = new DeleteCustomerGroupCommand { Id = id };
           
            return Ok(deleteCommand);
        }
    }
}
