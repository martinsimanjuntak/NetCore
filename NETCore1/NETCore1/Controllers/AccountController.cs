using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore1.Base;
using NETCore1.Models;
using NETCore1.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NETCore1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountRepository, string>

    {
        private readonly AccountRepository accountRepository;
        public AccountController(AccountRepository repository) : base(repository)
        {
            this.accountRepository = repository;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginModel loginModel)
        {
            var action = accountRepository.Login(loginModel);
            if (action == 1)
            {
                return Ok(new
                {
                    status = HttpStatusCode.OK,
                    message = "Login Success "
                });
            }
            else if(action == 0)
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.OK,
                    message = "Wrong Password "
                });
            }else 
            {
                return BadRequest(new
                {
                    status = HttpStatusCode.OK,
                    message = "Wrong Email"
                });
            }
           
        }
    }
}
