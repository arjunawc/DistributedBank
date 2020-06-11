using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.MVC.Models;
using WebUI.MVC.Models.DTO;
using WebUI.MVC.Services;

namespace WebUI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDto transferDto = new TransferDto()
            {
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount
            };

            var result = await _transferService.Transfer(transferDto);

            if (result.IsSuccess)
            {
                return View("Index");
            }

            return Json(new { Success = false, Message = result.ErrorMessage });
        }
    }
}
