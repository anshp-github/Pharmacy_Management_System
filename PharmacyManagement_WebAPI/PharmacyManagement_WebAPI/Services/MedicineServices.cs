using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class MedicineServices : IMedicineRepository
    {
        private readonly PharmacyDbContext _context;

        public MedicineServices(PharmacyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Medicine>> GetAllMedicines()
        {
            var records = await _context.Medicines.Select(x => new Medicine()
            {
                MedicineId = x.MedicineId,
                MedName = x.MedName,
                MedExpDate = x.MedExpDate,
                MedPrice = x.MedPrice,
                MedStock = x.MedStock,
                MedImage = x.MedImage,

            }).ToListAsync();
            return records;
        }
        public async Task<Medicine> GetMedicineByName(string MedName)
        {
            var records = await _context.Medicines.Where(x => x.MedName == MedName).Select(x => new Medicine()
            {
                MedicineId = x.MedicineId,
                MedName = x.MedName,
                MedExpDate = x.MedExpDate,
                MedPrice = x.MedPrice,
                MedStock = x.MedStock,
                MedImage=x.MedImage,    

            }).FirstOrDefaultAsync();
            return records;

        }
        public async Task<int> AddMedicine(Medicine medicine)
        {
            var med = new Medicine()
            {
                MedExpDate = medicine.MedExpDate,
                //MedicineId = medicine.MedicineId,
                MedName = medicine.MedName,
                MedPrice = medicine.MedPrice,
                MedStock = medicine.MedStock,
                MedImage = medicine.MedImage,

            };
            _context.Medicines.AddAsync(med);
            await _context.SaveChangesAsync();
            return med.MedicineId;


        }
        public async Task UpdateMedicine(int id, Medicine medicine)
        {
            var med = await _context.Medicines.FindAsync(id);
            if (med != null)
            {
                med.MedStock = medicine.MedStock;
                med.MedPrice = medicine.MedPrice;
                med.MedName = medicine.MedName;
                med.MedExpDate = medicine.MedExpDate;
                med.MedImage = medicine.MedImage;
            };

            await _context.SaveChangesAsync();

        }
        //public async Task UpdateMedicineByStock(int id, JsonPatchDocument medicine)
        //{
        //    var med = await _context.Medicines.FindAsync(id);

        //    if (med != null)
        //    {
        //        medicine.ApplyTo(med);
        //        await _context.SaveChangesAsync();

        //    }

        //}
        public async Task DeleteMedicine(int id)
        {
            var med = new Medicine() { MedicineId = id };
            _context.Medicines.Remove(med);
            await _context.SaveChangesAsync();
        }

    }
}
