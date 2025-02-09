    using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class InboundTransactionDetailReposotory:IInboundTransactionDetailRepository
    {
        private DataContext _context;
        public InboundTransactionDetailReposotory(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateInbTDetail(InboundTransactionDetail inboundTransactionDetail)
        {
            _context.InboundTransactionDetails.Add(inboundTransactionDetail);
            return Save();
        }

        public bool DeleteInbTDetail(InboundTransactionDetail inboundTransactionDetail)
        {
            _context.InboundTransactionDetails.Remove(inboundTransactionDetail);
            return Save();
        }

        public ICollection<InboundTransactionDetail> GetInbTDetails()
        {
            return _context.InboundTransactionDetails.OrderBy(e => e.Id).ToList();
        }

        public ICollection<InboundTransactionDetail> GetInbTDetailByInbound(int id)
        {
            return _context.InboundTransactionDetails.Where(e => e.InboundTransactionId == id).ToList();

        }

        public ICollection<InboundTransactionDetail> GetInbTDetailByProduct(int id)
        {
            return _context.InboundTransactionDetails.Where(e => e.ProductId == id).ToList();
        }

        public bool InbTDetailExists(int id)
        {
            return _context.InboundTransactionDetails.Any(e => e.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateInbTDetail(InboundTransactionDetail inboundTransactionDetail)
        {
            _context.InboundTransactionDetails.Update(inboundTransactionDetail);
            return Save();
        }

        public InboundTransactionDetail GetInbTDetail(int id)
        {
            return _context.InboundTransactionDetails.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
