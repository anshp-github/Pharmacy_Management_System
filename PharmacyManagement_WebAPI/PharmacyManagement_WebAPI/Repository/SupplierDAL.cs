using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public class SupplierDAL:ISupplierRepository
    {
        private readonly PharmacyDbContext _context;

        public SupplierDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Supplier>> GetAllSuppliers()
        {
            var records = await _context.Suppliers.Select(x => new Supplier()
            {
                SupplierId = x.SupplierId,
                SupplierName = x.SupplierName,
                SupplierEmail = x.SupplierEmail,
                MedicineId = x.MedicineId,
                Medicine = x.Medicine,



            }).ToListAsync();
            return records;
        }
        public async Task<int> AddSupplier(Supplier supplier)
        {
            var x = new Supplier()
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                SupplierEmail = supplier.SupplierEmail,
                MedicineId = supplier.MedicineId,


            };
            _context.Suppliers.Add(x);
            await _context.SaveChangesAsync();
            return x.SupplierId;


        }
        public async Task UpdateSupplier(int id, Supplier supplier)
        {
            var x = await _context.Suppliers.FindAsync(id);
            if (x != null)
            {
                x.SupplierId = supplier.SupplierId;
                x.SupplierName = supplier.SupplierName;
                x.SupplierEmail = supplier.SupplierEmail;
                x.MedicineId = supplier.MedicineId;

            };

            await _context.SaveChangesAsync();

        }


        public async Task DeleteSupplier(int id)
        {
            var supplier = new Supplier() { SupplierId = id };
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
