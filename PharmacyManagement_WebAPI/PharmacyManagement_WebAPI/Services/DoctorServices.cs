using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Services
{
    public class DoctorServices:IDoctorRepository
    {
        private readonly PharmacyDbContext _context;

        public DoctorServices(PharmacyDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            var records = await _context.Doctors.Select(x => new Doctor()
            {
                DoctorId = x.DoctorId,
                DocName = x.DocName,
                DocEmail = x.DocEmail,
                DocPhnNum = x.DocPhnNum,
                DocPassword = x.DocPassword,
                DocAddress = x.DocAddress,

            }).ToListAsync();
            return records;
        }
        public async Task<Doctor> GetDoctorByName(string DocName)
        {
            var records = await _context.Doctors.Where(x => x.DocName == DocName).Select(x => new Doctor()
            {
                DoctorId = x.DoctorId,
                DocName = x.DocName,
                DocEmail = x.DocEmail,
                DocPhnNum = x.DocPhnNum,
                DocPassword = x.DocPassword,
                DocAddress = x.DocAddress,

            }).FirstOrDefaultAsync();
            return records;

        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
            var doc = new Doctor()
            {
                //DoctorId = doctor.DoctorId,
                DocName = doctor.DocName,
                DocEmail = doctor.DocEmail,
                DocPhnNum = doctor.DocPhnNum,
                DocPassword = doctor.DocPassword,
                DocAddress = doctor.DocAddress,

            };
            _context.Doctors.AddAsync(doc);
            await _context.SaveChangesAsync();
            return doc.DoctorId;


        }
        public async Task DeleteDoctor(int id)
        {
            var doc = new Doctor() { DoctorId = id };
            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
        }
    }
}
