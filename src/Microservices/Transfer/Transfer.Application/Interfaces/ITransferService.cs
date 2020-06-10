using DistributedBank.Services.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
