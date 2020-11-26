using DoctorManagement.Models;
using DoctorManagement.Repository;
using DoctorManagement.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorManagement.Services.Doctors
{
    public class ListDoctors
    {
        public class GetAllDoctorsQuery : IRequest<Response> { }

        public class GettAllDoctorsHandler : IRequestHandler<GetAllDoctorsQuery, Response>
        {

            private readonly IDoctorRepository _doctorRepository;
            public Response response = new Response();

            public GettAllDoctorsHandler(IDoctorRepository doctorRepository)
            {
                _doctorRepository = doctorRepository;
            }

            public async Task<Response> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
            {
                var docs = await _doctorRepository.GetAllDoctors();

                response.error = false;
                response.data = docs;
                response.message = "all doctors returned";

                return response;
            }
        }
    }
}
