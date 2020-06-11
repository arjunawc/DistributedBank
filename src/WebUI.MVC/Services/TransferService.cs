using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.MVC.Models.DTO;

namespace WebUI.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TransferService> _logger;

        public TransferService(IHttpClientFactory httpClientFactory, ILogger<TransferService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> Transfer(TransferDto transferDto)
        {
            try
            {
                var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                                        System.Text.Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient("AccountingService");
                var response = await client.PostAsync("api/accounting", transferContent);
                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }

                return (false, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return (false, ex.Message);
            }
        }
    }
}
