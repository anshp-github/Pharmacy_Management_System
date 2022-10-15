using Microsoft.EntityFrameworkCore;
using PharmacyManagement_WebAPI.Models;

namespace PharmacyManagement_WebAPI.Repository
{
    public class DoctorRegistrationDAL:IDoctorRepository
    {
        private readonly PharmacyDbContext _context;

        public DoctorRegistrationDAL(PharmacyDbContext context)
        {
            _context = context;
        }
        public async Task<List<DoctorRegistration>> GetAllDoctors()
        {
            var records = await _context.Doctors.Select(x => new DoctorRegistration()
            {
                DoctorId = x.DoctorId,
                DocName = x.DocName,
                DocEmail = x.DocEmail,
                DocPhnNum = x.DocPhnNum,
                DocPassword = x.DocPassword,
                DocAddress = x.DocAddress,
                Role=x.Role,

            }).ToListAsync();
            return records;
        }
        public async Task<DoctorRegistration> GetDoctorByName(string DocEmail)
        {
            var records = await _context.Doctors.Where(x => x.DocEmail == DocEmail).Select(x => new DoctorRegistration()
            {
                DoctorId = x.DoctorId,
                DocName = x.DocName,
                DocEmail = x.DocEmail,
                DocPhnNum = x.DocPhnNum,
                DocPassword = x.DocPassword,
                DocAddress = x.DocAddress,
                Role = x.Role,

            }).FirstOrDefaultAsync();
            return records;

        }
        public async Task<int> AddDoctor(DoctorRegistration doctor)
        {
            var doc = new DoctorRegistration()
            {
                //DoctorId = doctor.DoctorId,
                DocName = doctor.DocName,
                DocEmail = doctor.DocEmail,
                DocPhnNum = doctor.DocPhnNum,
                DocPassword = doctor.DocPassword,
                DocAddress = doctor.DocAddress,
                Role="Doctor",

            };
            _context.Doctors.AddAsync(doc);
            await _context.SaveChangesAsync();
            return doc.DoctorId;


        }
        public async Task DeleteDoctor(int id)
        {
            var doc = new DoctorRegistration() { DoctorId = id };
            _context.Doctors.Remove(doc);
            await _context.SaveChangesAsync();
        }
    }
}
