using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorByName(string DocName);
        Task<int> AddDoctor(Doctor doctor);
        Task DeleteDoctor(int id);
    }
}
