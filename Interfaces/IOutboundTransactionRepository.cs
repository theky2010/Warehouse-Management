using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IOutboundTransactionRepository
    {
        ICollection<OutboundTransaction> GetOutboundTransactions();
        OutboundTransaction GetOutboundTransaction(int id);
        ICollection<OutboundTransaction> GetOutbTransactionByCustomer(int id);
        ICollection<OutboundTransaction> GetOutbTransactionByWarehouse(int id);
        bool Save();
        bool CreateOutboundTransaction(OutboundTransaction outboundTransaction);
        bool UpdateOutboundTransaction(OutboundTransaction outboundTransaction);
        bool DeleteOutboundTransaction(OutboundTransaction outboundTransaction);
        bool OutboundTransactionExists(int id);
    }
}
