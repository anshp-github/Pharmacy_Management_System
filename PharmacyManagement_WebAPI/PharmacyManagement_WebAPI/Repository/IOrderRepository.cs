using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<int> AddOrder(Order order);
    }
}
