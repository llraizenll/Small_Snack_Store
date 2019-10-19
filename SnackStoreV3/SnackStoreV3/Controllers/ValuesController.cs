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
            if( item == null ) item= new GetProductsDto();          
            var result = await _repoSnack.GetAllSnacksPagination(new PaginationDTO
            {
                PageNumber = item.PageNumber,
                PageSize = item.PageSize,
                SortBy = item.SortBy.ToString(),
                Order = item.Order.ToString()
            });
            return Ok(result.Select(x => new GetProductsResponseDto
            {
                Id = x.snackId,
                Name = x.snackName,
                Price = x.snackPrice,
                Likes = x.snackLikes
            }));

        }


        [HttpGet]
        [Route("Snack")]
        public async Task<IActionResult> GetSnackByName ([FromQuery] string name)
        {

            var data = await _repoSnack.GetSnackByName(name);
            if (data == null) return NotFound();
            else
                return Ok(new GetProductsResponseDto
                {
                    Id = data.snackId,
                    Name = data.snackName,
                    Likes = data.snackLikes,
                    Price = data.snackPrice,
                    Stock = data.SnackQuantity,
                });
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
