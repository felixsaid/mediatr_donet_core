using DoctorManagement.Models;
using DoctorManagement.Repository;
using DoctorManagement.Utils;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorManagement.Services.Doctors
{
    public class CreateDoctor
    {
        public class CreateDoctorCommand : IRequest<Response>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public int HudumaNumber { get; set; }

        }

        public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, Response>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly ILogger<CreateDoctorHandler> _logger;
            public Response response = new Response();

            public CreateDoctorHandler(IDoctorRepository doctorRepository, ILogger<CreateDoctorHandler> logger)
            {
                _doctorRepository = doctorRepository;
                _logger = logger;
            }

            public async Task<Response> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                    var doc = await _doctorRepository.CreateDoctor(new Doctor() { FirstName = request.FirstName, LastName = request.LastName, HudumaNumber = request.HudumaNumber});
                    _logger.LogInformation($"Doctor was successfully created.");

                    response.error = false;
                    response.data = doc;
                    response.message = "doctor was successfully registered.";

                    return response;

            }
        }
    }
}
