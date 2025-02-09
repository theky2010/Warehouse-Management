using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class OutboundTransactionDetailRepository:IOutboundTransactionDetailRepository
    {
        private DataContext _context;
        public OutboundTransactionDetailRepository(DataContext datacontext)
        {
            _context = datacontext;
        }

        public bool CreateOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail)
        {
            _context.OutboundTransactionDetails.Add(outboundTransactionDetail);
            return Save();
        }

        public bool DeleteOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail)
        {
            _context.OutboundTransactionDetails.Remove(outboundTransactionDetail);
            return Save();
        }

        public OutboundTransactionDetail GetOutboundTransactionDetail(int id)
        {
            return _context.OutboundTransactionDetails.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<OutboundTransactionDetail> GetOutboundTransactionDetails()
        {
            return _context.OutboundTransactionDetails.OrderBy(e => e.Id).ToList();
        }

        public ICollection<OutboundTransactionDetail> GetOutbTDetailByOutbound(int id)
        {
            return _context.OutboundTransactionDetails.Where(e => e.OutboundTransactionId == id).ToList();
        }

        public ICollection<OutboundTransactionDetail> GetOutbTDetailByWarehouse(int id)
        {
            return _context.OutboundTransactionDetails.Where(e => e.WarehouseLocationId == id).ToList();
        }

        public bool OutboundTransactionDetailExists(int id)
        {
            return _context.OutboundTransactionDetails.Any(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOutboundTransactionDetail(OutboundTransactionDetail outboundTransactionDetail)
        {
            _context.OutboundTransactionDetails.Update(outboundTransactionDetail);
            return Save();
        }
    }
}
