using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IInboundTransactionDetailRepository
    {
        bool InbTDetailExists(int id);
        ICollection<InboundTransactionDetail> GetInbTDetails();
        InboundTransactionDetail GetInbTDetail(int id);
        ICollection<InboundTransactionDetail> GetInbTDetailByProduct(int id);
        ICollection<InboundTransactionDetail> GetInbTDetailByInbound(int id);
        bool Save();
        bool CreateInbTDetail(InboundTransactionDetail inboundTransactionDetail);
        bool UpdateInbTDetail(InboundTransactionDetail inboundTransactionDetail);
        bool DeleteInbTDetail(InboundTransactionDetail inboundTransactionDetail);
    }
}
