using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
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
        private IValidator<SnackModel> _entityToValidate;
        public ValuesController(StoreDbContext context, ISnackRepository repoSnack, IValidator<SnackModel> entityToValidate)
        {
            _context = context;
            _repoSnack = repoSnack;
            _entityToValidate =entityToValidate;
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
                    Stock = data.snackQuantity,
                });
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateSnackDTO obj)
        {
            List<string> errorList = new List<string>();
            var newSnack= new SnackModel()
            {
                snackName = obj.name,               
                snackPrice = obj.price,
                snackQuantity = obj.quantity,
            };

            var result = _entityToValidate.Validate(newSnack);
            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    errorList.Add(error.ToString());
                }
                return BadRequest(errorList);
            }
             await _repoSnack.CreateSnack(newSnack);            
             return Ok();

        }


        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repoSnack.GetSnacksById(id);
            if (product == null) return NotFound();


            await _repoSnack.DeleteSnack(product);
            return Ok();
        }
        // PUT api/values/5
        [HttpPut]
        [Route("price")]
        public async Task<IActionResult> Price([FromQuery]int id, double newPrice)
        {
            var product = await _repoSnack.GetSnacksById(id);
            if (product == null) return NotFound();

            
           await _repoSnack.UpdatePriceSnack(product,newPrice);
            return Ok();

        }

        //[HttpPut]  
        //[Route("buy/{id}")]
        //public async Task<IActionResult> Buy(int id, [FromQuery]int quantity)
        //{
        //    var product = await _repoSnack.GetSnacksById(id);
        //    if (product == null) return NotFound();

           




    }
}
