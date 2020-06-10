using DistributedBank.Services.Transfer.Domain.Models;
using System.Collections.Generic;

namespace DistributedBank.Services.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
