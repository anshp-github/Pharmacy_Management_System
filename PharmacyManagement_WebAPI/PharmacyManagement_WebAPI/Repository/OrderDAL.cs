using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public class OrderDAL:IOrderRepository
    {
        private readonly PharmacyDbContext _context;

        public OrderDAL(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var records = await _context.Orders.Select(o => new Order()
            {
                OrderDate = o.OrderDate,
                OrderId = o.OrderId,
                Amount = o.Amount,
                Count = o.Count,
                IsPickedUp = o.IsPickedUp,
                Admin = o.Admin,
                AdminId = o.AdminId,
                Doctor = o.Doctor,
                DoctorId = o.DoctorId,
                Medicine = o.Medicine,
                MedicineId = o.MedicineId,
            }).ToListAsync();

            return records;

        }
        public async Task<List<Order>> GetOrdersReport(DateTime From,DateTime To)
        {
            
            var records = await _context.Orders.Where(o => o.OrderDate > From && o.OrderDate < To)
                .Select(o => new Order()
            {
                OrderDate = o.OrderDate,
                OrderId = o.OrderId,
                Amount = o.Amount,
                Count = o.Count,
                IsPickedUp = o.IsPickedUp,
                Admin = o.Admin,
                AdminId = o.AdminId,
                Doctor = o.Doctor,
                DoctorId = o.DoctorId,
                Medicine = o.Medicine,
                MedicineId = o.MedicineId,

            }).ToListAsync();
            return records;
           
        }
        public async Task<int> AddOrder(Order order)
        {

            var record = new Order()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                Amount = order.Amount,
                Count = order.Count,
                // Admin = order.Admin,
                AdminId = order.AdminId,
                // Doctor= order.Doctor,
                DoctorId = order.DoctorId,
                MedicineId = order.MedicineId,


            };

            _context.Orders.Add(record);
            await _context.SaveChangesAsync();
            return record.OrderId;

        }
    }
}
