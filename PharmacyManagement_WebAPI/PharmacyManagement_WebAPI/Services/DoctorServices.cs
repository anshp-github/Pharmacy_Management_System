using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class DoctorServices
    {
         IDoctorRepository _doctor;

        public DoctorServices(IDoctorRepository doctor)
        {
            _doctor = doctor;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
          return await _doctor.GetAllDoctors();
        }
        public async Task<Doctor> GetDoctorByName(string DocName)
        {
            return await _doctor.GetDoctorByName(DocName);

        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
           return await _doctor.AddDoctor(doctor);


        }
        public async Task DeleteDoctor(int id)
        {
             await _doctor.DeleteDoctor(id);
        }
    }
}
