using DistributedBank.Services.Transfer.Application.Interfaces;
using DistributedBank.Services.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DistributedBank.Services.Transfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        // GET api/transfer
        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
