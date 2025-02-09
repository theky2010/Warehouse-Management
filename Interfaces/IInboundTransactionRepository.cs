using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IInboundTransactionRepository
    {
        bool IbTExists(int id);
        ICollection<InboundTransaction> GetInboundTransactions();
        InboundTransaction GetInboundTransaction(int id);
        ICollection<InboundTransaction> GetInbByWarehouse(int id);
        bool Save();
        bool CreateInboundTransaction(InboundTransaction inboundTransaction);
        bool UpdateInboundTransaction(InboundTransaction inboundTransaction);
        bool DeleteInboundTransaction(InboundTransaction inboundTransaction);
    }
}
