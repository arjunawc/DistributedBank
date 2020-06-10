using DistributedBank.Services.Accounting.Application.Interfaces;
using DistributedBank.Services.Accounting.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DistributedBank.Services.Accounting.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET api/accounting
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }
    }
}
