using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SnackStoreV3.Commons;
using SnackStoreV3.Domain.Interfaces;
using SnackStoreV3.Domain.Models;
using SnackStoreV3.Models;
using SnackStoreV3.Repository;
using SnackStoreV3.Repository.DTO;

namespace SnackStoreV3.Controllers
{
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository _accountRepository;
        private readonly ItokenFactory _tokenFactory;

        public AccountController(IUserAccountRepository accountRepository, ItokenFactory tokenFactory)
        {
            _accountRepository = accountRepository;
            _tokenFactory = tokenFactory;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterAccountDto item)
        {
            var account = await _accountRepository.GetByUserName(item.UserName);
            if (account != null)
                return Error($"Account with username :{item.UserName} already registered.");

            await _accountRepository.CreateAccount(new UserAccounts
            {
                UserName = item.UserName,
                Password = item.Password.ToSha256(),
                Role = item.Role
            });
            return Ok();
        }

        private IActionResult Error(string v)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LogingDTO item)
        {
            var account = await _accountRepository.GetByUserNameAndPassword(item.UserName, item.Password.ToSha256());

            if (account == null)
                return NotFound($"Account with username :{item.UserName} not found.");

            var token = _tokenFactory.GenerateToken(account.UserName, account.Role);
            if (token==null){
                return Unauthorized();
            }
            else
            {
                return Ok(new ResponseTokenDto { 
                        code= HttpStatusCode.OK,
                        userAccessToken=token
                
                });
            }

           // return token == null ?  : Ok(token);
        }



    }
}
