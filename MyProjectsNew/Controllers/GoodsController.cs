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

        public GoodsController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("{id}/getGoodsName")]
        public async Task<ActionResult<List<Goods>>> GetGoodsName()
        {
            var Goodsname = await _db.Goods.ToListAsync();
            return Ok(Goodsname);
        }
        
        [HttpPost]
        [Route("{id}")]

        public async Task<ActionResult<List<CustomerPersonnelNames>>> CreateGoodsName([FromBody] GoodsName GoodsNameModel)
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
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<CustomerPersonnelNames>>> UpdateGoodsName([FromBody] GoodsName GoodsNameModel)
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

        [HttpDelete]
        public async Task<ActionResult<List<GoodsName>>> DeleteGoodsName([FromRoute][Required] long id) //yani chi Required?
        {
            var deleteCommand = new DeleteGoodsNameCommand { Id = id };

            return Ok(deleteCommand);
        }
    }
}
