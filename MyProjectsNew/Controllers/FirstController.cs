using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectsNew.Data;
using MyProjectsNew.Entities;

namespace MyProjectsNew.Controller
    {
    [Route("api/[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {

        private readonly DataContext _db;

        public FirstController(DataContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get the Customers Name and Show it Here
        /// </summary>
        /// <returns>if succeed return Customers names</returns>
        [HttpGet("getCustomerName")]
        public async Task<ActionResult<List<CustomerName>>> GetAllPersonnel()
        {

            var personnelname = await _db.CustomerName.ToListAsync();
            return Ok(personnelname);

        }


        [HttpPost]
        public async Task<ActionResult<List<CustomerPersonnelNames>>> AddPersonnelWelfare([FromBody] CustomerPersonnelNames CustomerName)
        {
            _db.CustomerName.FirstOrDefaultAsync();
            await _db.AddRangeAsync();
            return Ok(CustomerName);


        }


        [HttpGet("{id}/getGoodsName")]
        public async Task<ActionResult<List<Goods>>> GetGoodsName()
        {

            var Goodsname = await _db.Goods.ToListAsync();
            return Ok(Goodsname);

        }


    }
}
