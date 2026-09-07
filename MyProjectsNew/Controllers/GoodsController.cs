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
        public async Task<ActionResult<List<GoodsName>>> GetGoodsName()
        {
            var Goodsname = await _db.GoodsName.ToListAsync();
            return Ok(Goodsname);
        }


        /// <summary>
        /// Get the Goods by id and Show it Here
        /// </summary>
        /// <returns>if succeed return Goods names</returns>
        [HttpGet]
        [Route("getGoodsNameById/{id}")]
        public async Task<ActionResult<GoodsName>> GetGoodsNameById(int id)
        {
            var GoodsName = await _db.GoodsName
                .Where(x => x.Code == id)
                .FirstOrDefaultAsync();

            return GoodsName;
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
            _db.GoodsName.Add(command);
            await _db.SaveChangesAsync();

            return Ok(command);


        }
        /// <summary>
        /// Update the Goods and Show it Here
        /// </summary>
        /// <returns>UpdateGoodsName</returns>
        [HttpPut]
        [Route("UpdateGoodsName")]
        public async Task<ActionResult<GoodsName>> UpdateGoodsName([FromBody] GoodsName GoodsNameModel)
        {
            var goodsName = await _db.GoodsName
                .FirstOrDefaultAsync(x => x.Code == GoodsNameModel.Code);

            if (goodsName == null)
            {
                return NotFound("GoodsName not found.");
            }

            goodsName.Name = GoodsNameModel.Name;
            goodsName.CustomerGoodsName = GoodsNameModel.CustomerGoodsName;
            goodsName.GoodsCount = GoodsNameModel.GoodsCount;
            goodsName.GoodsPrice = GoodsNameModel.GoodsPrice;

            await _db.SaveChangesAsync();

            return Ok(goodsName);
        }
        /// <summary>
        /// Delete the Goods and Show it Here
        /// </summary>
        /// <returns>DeleteGoodsName</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoodsName(int id)
        {
            var goodsName = await _db.GoodsName.Where(x=> x.Code == id)
                .FirstOrDefaultAsync();

            if (goodsName == null)
                return NotFound();

            _db.GoodsName.Remove(goodsName);

            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
