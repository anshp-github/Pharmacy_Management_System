using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class SupplierServices
    {
        ISupplierRepository _supplier;
        public SupplierServices(ISupplierRepository supplier)
        {
            _supplier = supplier;
        }
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _supplier.GetAllSuppliers();
        }
        public async Task<int> AddSupplier(Supplier supplier)
        {
            return await _supplier.AddSupplier(supplier);
        }
        public async Task UpdateSupplier(int id, Supplier supplier)
        {
            await _supplier.UpdateSupplier(id, supplier);
        }
        public async Task DeleteSupplier(int id)
        {
            await _supplier.DeleteSupplier(id);
        }
    }
}
