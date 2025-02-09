using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IOutboundTransactionDetailRepository
    {
        ICollection<OutboundTransactionDetail> GetOutboundTransactionDetails();
        OutboundTransactionDetail GetOutboundTransactionDetail(int id);
        ICollection<OutboundTransactionDetail> GetOutbTDetailByOutbound(int id);
        ICollection<OutboundTransactionDetail> GetOutbTDetailByWarehouse(int id);
        bool Save();
        bool CreateOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail);
        bool UpdateOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail);
        bool DeleteOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail);
        bool OutboundTransactionDetailExists(int id);
    }
}
