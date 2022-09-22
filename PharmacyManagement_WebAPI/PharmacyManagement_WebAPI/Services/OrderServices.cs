using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class OrderServices:IOrderRepository
    {
        private readonly PharmacyDbContext _context;

        public OrderServices(PharmacyDbContext context)
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
