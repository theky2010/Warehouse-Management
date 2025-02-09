using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class InboundTransactionRepository : IInboundTransactionRepository
    {
        private DataContext _context;
        public InboundTransactionRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateInboundTransaction(InboundTransaction inboundTransaction)
        {
            _context.InboundTransactions.Add(inboundTransaction);
            return Save();
        }

        public bool DeleteInboundTransaction(InboundTransaction inboundTransaction)
        {
            _context.InboundTransactions.Remove(inboundTransaction);
            return Save();
        }

        public ICollection<InboundTransaction> GetInbByWarehouse(int id)
        {
            return _context.InboundTransactions.Where(e => e.WarehouseId == id).ToList();
        }

        public InboundTransaction GetInboundTransaction(int id)
        {
            return _context.InboundTransactions.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<InboundTransaction> GetInboundTransactions()
        {
            return _context.InboundTransactions.OrderBy(e => e.Id).ToList();
        }

        public bool IbTExists(int id)
        {
            return _context.InboundTransactions.Any(e => e.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateInboundTransaction(InboundTransaction inboundTransaction)
        {
            _context.InboundTransactions.Update(inboundTransaction);
            return Save();
        }
    }
}
