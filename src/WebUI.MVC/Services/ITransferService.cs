using System.Threading.Tasks;
using WebUI.MVC.Models.DTO;

namespace WebUI.MVC.Services
{
    public interface ITransferService
    {
        Task<(bool IsSuccess, string ErrorMessage)> Transfer(TransferDto transferDto);
    }
}
