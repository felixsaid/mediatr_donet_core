using DoctorManagement.Repository;
using DoctorManagement.Services.Doctors;
using DoctorManagement.Utils;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DoctorManagement.Services.Doctors.CreateDoctor;
using static DoctorManagement.Services.Doctors.ListDoctorsById;

namespace DoctorManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Response response = new Response();
        public ErrorResponse errorResponse = new ErrorResponse();

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public  async Task<IActionResult> GetAllDocs()
        {
                var query = new ListDoctors.GetAllDoctorsQuery();
                var results = await _mediator.Send(query);

                return Ok(results);
        }


        [HttpGet]
        [Route("{doctorId}")]
        public async Task<IActionResult> GetAllDocById(int doctorId)
        {

            var query = new GetDoctorByIdQuery(doctorId);
            var result = await _mediator.Send(query);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);

        }
    }
}
