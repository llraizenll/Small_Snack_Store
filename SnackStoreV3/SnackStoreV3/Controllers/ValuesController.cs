using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SnackStoreV3.Commons;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Dto;
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
        private ILogPriceRepository _logPrice;
        private IValidator<SnackModel> _entityToValidate;
        private IBuySnacks _buySnacks;
        private readonly ItokenFactory _tokenFactory;

        private ILogPurchaseRepository _logPurchase;
        public ValuesController(StoreDbContext context, ISnackRepository repoSnack, IValidator<SnackModel> entityToValidate,
            ILogPriceRepository logPrice, IBuySnacks buySnacks, ILogPurchaseRepository logPurchase, ItokenFactory tokenFactory)
        {
            _context = context;
            _repoSnack = repoSnack;
            _entityToValidate =entityToValidate;
            _logPrice = logPrice;
            _buySnacks =buySnacks;
            _logPurchase = logPurchase;
            _tokenFactory = tokenFactory;
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
                Likes = x.snackLikes,
                Stock=x.snackQuantity
            }));

        }


        [HttpGet]
        [Route("SearchSnackByName")]
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
        [Route("AddSnacks")]
        [Authorize(Roles = "Admin")]
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
        [Route("RemoveSnacks")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repoSnack.GetSnacksById(id);
            if (product == null) return NotFound();


            await _repoSnack.DeleteSnack(product);
            return Ok();
        }
        // PUT api/values/5
        [HttpPut]
        [Route("ModifiedPrice")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Price([FromQuery]int id, double newPrice)
        {
            var product = await _repoSnack.GetSnacksById(id);
            if (product == null) return NotFound();

            
           await _repoSnack.UpdatePriceSnack(product,newPrice);
            await _logPrice.ChangePrice(product.snackName, product.snackPrice, newPrice);
            return Ok();

        }



        [HttpGet]
        [Route("GetLogPrices")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetChangePriceLog()
        {

            var result = await _logPrice.GetLogChangePrices();
            return Ok(new ResponseLogsDto
            {
                Code = HttpStatusCode.OK,
                Data = result

            }) ;

        }

        [HttpPut]
        [Route("buy/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Buy(int id, [FromQuery]int quantity)
        {
            var product = await _repoSnack.GetSnacksById(id);
            if (product == null) return NotFound("This product doesnt exist");
            var userNameClaim = _tokenFactory.GetUser();
            var res =_buySnacks.BuySnacks(product, quantity);
            await _logPurchase.SavePurchase(userNameClaim, quantity);
            return Ok(new ResponseTokenDto
            {
                code = HttpStatusCode.OK,
                userAccessToken = res.Result

            });

        }
        [HttpGet]
        [Route("GetLogPurchase")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetPurchaseLog()
        {

            var result = await _logPurchase.GetLogPurchase();
            return Ok(new ResponseLogPurchaseDto
            {
                Code = HttpStatusCode.OK,
                Data = result

            });

        }

    }
}
