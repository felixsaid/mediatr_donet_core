using DoctorManagement.Models;
using DoctorManagement.Repository;
using DoctorManagement.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.DataManager
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DatabaseContext _context;

        public DoctorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctorItem)
        {
            _context.Add(doctorItem);
            await _context.SaveChangesAsync();

            return doctorItem;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            var docs = (from d in _context.doctors
                                             select d).ToListAsync();

            return await docs;
        }

        public async Task<Doctor> GetDoctorById(int doctorId)
        {
            var docs = (from d in _context.doctors
                        select d).FirstOrDefaultAsync(a => a.DoctorId == doctorId);

            return await docs;
        }
    }
}
