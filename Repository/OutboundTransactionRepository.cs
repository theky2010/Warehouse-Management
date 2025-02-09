using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class OutboundTransactionRepository:IOutboundTransactionRepository
    {
        private DataContext _context;
        public OutboundTransactionRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateOutboundTransaction(OutboundTransaction outboundTransaction)
        {
            _context.OutboundTransactions.Add(outboundTransaction);
            return Save();
        }

        public bool DeleteOutboundTransaction(OutboundTransaction outboundTransaction)
        {
            _context.OutboundTransactions.Remove(outboundTransaction);
            return Save();
        }

        public OutboundTransaction GetOutboundTransaction(int id)
        {
            return _context.OutboundTransactions.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<OutboundTransaction> GetOutboundTransactions()
        {
            return _context.OutboundTransactions.OrderBy(e => e.Id).ToList();
        }

        public ICollection<OutboundTransaction> GetOutbTransactionByCustomer(int id)
        {
            return _context.OutboundTransactions.Where(e => e.CustomerId == id).ToList();
        }

        public ICollection<OutboundTransaction> GetOutbTransactionByWarehouse(int id)
        {
            return _context.OutboundTransactions.Where(e => e.WarehouseId == id).ToList();
        }

        public bool OutboundTransactionExists(int id)
        {
            return _context.OutboundTransactions.Any(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOutboundTransaction(OutboundTransaction outboundTransaction)
        {
            _context.OutboundTransactions.Update(outboundTransaction);
            return Save();
        }
    }
}
