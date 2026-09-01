using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjectsNew.Contracts;
using MyProjectsNew.Data;
using MyProjectsNew.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyProjectsNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly DataContext _db;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <returns>Constructor for GoodsController</returns>
        public GoodsController(DataContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Get the Goods Name and Show it Here
        /// </summary>
        /// <returns>if succeed return Goods names</returns>
        [HttpGet]
        [Route("getGoodsName")]
        public async Task<ActionResult<List<Goods>>> GetGoodsName()
        {
            var Goodsname = await _db.Goods.ToListAsync();
            return Ok(Goodsname);
        }
        /// <summary>
        /// Post the Goods and Show it Here
        /// </summary>
        /// <returns>CreateCustomerName</returns>
        [HttpPost]
        [Route("CreateGoodsName")]

        public async Task<ActionResult<List<GoodsName>>> CreateGoodsName([FromBody] GoodsName GoodsNameModel)
        {
            var command = new GoodsName
            {
                GoodsPrice = GoodsNameModel.GoodsPrice,
                CustomerGoodsName = GoodsNameModel.CustomerGoodsName,
                Code = GoodsNameModel.Code,
                GoodsCount = GoodsNameModel.GoodsCount,
                Name = GoodsNameModel.Name

            };
            await _db.AddRangeAsync();
            return Ok(command);


        }
        /// <summary>
        /// Update the Goods and Show it Here
        /// </summary>
        /// <returns>UpdateGoodsName</returns>
        [HttpPut]
        [Route("UpdateGoodsName")]
        public async Task<ActionResult<List<GoodsName>>> UpdateGoodsName([FromBody] GoodsName GoodsNameModel)
        {
            var command = new GoodsName
            {
                GoodsPrice = GoodsNameModel.GoodsPrice,
                CustomerGoodsName = GoodsNameModel.CustomerGoodsName,
                Code = GoodsNameModel.Code,
                GoodsCount = GoodsNameModel.GoodsCount,
                Name = GoodsNameModel.Name
            };
            await _db.AddAsync(command);
            return Ok(command);

        }
        /// <summary>
        /// Delete the Goods and Show it Here
        /// </summary>
        /// <returns>DeleteGoodsName</returns>
        [HttpDelete]
        public async Task<ActionResult<List<GoodsName>>> DeleteGoodsName([FromRoute][Required] long id) //yani chi Required?
        {
            var deleteCommand = new DeleteGoodsNameCommand { Id = id };

            return Ok(deleteCommand);
        }
    }
}
