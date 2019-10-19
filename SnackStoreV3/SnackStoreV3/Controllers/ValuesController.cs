using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackStoreV3.Domain.Interfaces;

using SnackStoreV3.Models;
using SnackStoreV3.Repository;
using SnackStoreV3.Repository.DTO;

namespace SnackStoreV3.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StoreDbContext _context;
        private ISnackRepository _repoSnack;
        public ValuesController(StoreDbContext context, ISnackRepository repoSnack)
        {
            _context = context;
            _repoSnack = repoSnack;
        }

        [HttpGet]
        public async Task<IActionResult> Product([FromQuery]GetProductsDto item = null)
        {
            item = item ?? new GetProductsDto();
            //var data = _repoSnack.GetAllSnacks();
            var result = await _repoSnack.GetAllProductsChunk(new PaginationDTO
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize,
                SortBy = item.SortBy.ToString(),
                Order = item.Order.ToString()
            });
            return Ok(result.Select(a => new GetProductsResponseDto
            {
                Id = a.likingSnack,
                Name = a.snackName,
                Price = a.snackLikes,
                Likes = a.likingSnack
            }));

        }


        //[HttpGet]
        //[Route("Snack")]
        //public ActionResult<string> GetProductByName([FromQuery] string name)
        //{

        //    var data = _context.Snack.GetProductByName(x=>x.nameSnack==name);
        //    if (data == null) return NotFound();
        //    else
        //        return Ok(data.Select(a => new SnackDTO
        //    {
        //        snackId = a.likingSnack,
        //        nameSnack = a.nameSnack,
        //        priceSnack = a.priceSnack,
        //        likingSnack = a.likingSnack
        //    }));
        //}

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
