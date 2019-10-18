using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackStoreV3.Repository;
using SnackStoreV3.Repository.DTO;

namespace SnackStoreV3.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private StoreDbContext _context;

        public ValuesController(StoreDbContext context)
        {
            _context = context;
        }
      
        [HttpGet]
        public async Task<IActionResult> Product()
        {
            var data = _context.Snack.ToList();
            return Ok(data.Select(a => new SnackDTO
            {
                snackId = a.likingSnack,
                nameSnack = a.nameSnack,
                priceSnack = a.priceSnack,
                likingSnack = a.likingSnack
            }));
            
        }
        // GET api/values/5
        [HttpGet]
        [Route("Snack")]
        public ActionResult<string> GetProductByName([FromQuery] string name)
        {
            var data = _context.Snack.Where(x=>x.nameSnack==name);
            if (data == null) return NotFound();
            else
                return Ok(data.Select(a => new SnackDTO
            {
                snackId = a.likingSnack,
                nameSnack = a.nameSnack,
                priceSnack = a.priceSnack,
                likingSnack = a.likingSnack
            }));
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
