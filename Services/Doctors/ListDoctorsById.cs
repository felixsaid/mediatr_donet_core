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
    public class ListDoctorsById
    {
        public class GetDoctorByIdQuery : IRequest<Response> 
        {
            public int _doctorId { get; }

            public GetDoctorByIdQuery(int doctorId)
            {
                _doctorId = doctorId;
            }
        }

        public class ListDoctorsByIdHandler : IRequestHandler<GetDoctorByIdQuery, Response>
        {
            private readonly IDoctorRepository _doctorRepository;
            public Response response = new Response();

            public ListDoctorsByIdHandler(IDoctorRepository doctorRepository)
            {
                _doctorRepository = doctorRepository;
            }

            public async Task<Response> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
            {
                var docs = await _doctorRepository.GetDoctorById(request._doctorId);

                if(docs == null)
                {
                    return null;
                }

                response.error = false;
                response.data = docs;
                response.message = "doctor was successfully returned.";

                return response;
            }
        }
    }
}
