using DoctorManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorManagement.Repository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int doctorId);
        Task<Doctor> CreateDoctor(Doctor doctorItem);
    }
}
