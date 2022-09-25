using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class MedicineServices 
    {
        IMedicineRepository _medicine;
        public MedicineServices(IMedicineRepository medicine)
        {
            _medicine = medicine;
        }
        public async Task<List<Medicine>> GetAllMedicines()
        {
            return await _medicine.GetAllMedicines();
        }
        public async Task<Medicine> GetMedicineByName(string MedName)
        {
            return await _medicine.GetMedicineByName(MedName);
        }
        public async Task<int> AddMedicine(Medicine medicine)
        {
           return await _medicine.AddMedicine(medicine);
        }
        public async Task UpdateMedicine(int id, Medicine medicine)
        {
            await _medicine.UpdateMedicine(id, medicine);
        }
        public async Task DeleteMedicine(int id)
        {
            await _medicine.DeleteMedicine(id);
        }
    }
}
