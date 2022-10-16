using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class OrderServices
    {
        IOrderRepository _order;
        public OrderServices(IOrderRepository order)
        {
            _order = order;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _order.GetAllOrders();
        }
        public async Task<int> AddOrder(Order order)
        {
            return await _order.AddOrder(order);
        }
        public async Task<List<Order>> GetOrdersReport(DateTime From, DateTime To)
        {
            return await _order.GetOrdersReport(From, To);
        }
        public async Task UpdateOrder(int id, Order order)
        {
           await _order.UpdateOrder( id, order);
        }
        public async Task<List<Order>> GetOrdersConfirmation()
        {
            return await _order.GetOrdersConfirmation();
        }
    }
}
