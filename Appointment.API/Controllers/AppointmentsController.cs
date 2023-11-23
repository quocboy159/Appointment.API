using Appointment.Application.Dtos;
using Appointment.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Appointment.API.Controllers
{
    public class AppointmentsController : ODataController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [EnableQuery]
        public ActionResult<IEnumerable<AppointmentDto>> Get()
        {
            return Ok(_appointmentService.GetAll());
        }

        [EnableQuery]
        public async Task<ActionResult<AppointmentDto>> Get([FromRoute] int key)
        {
            var item = await _appointmentService.GetByIdAsync(key);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [ODataIgnored]
        [HttpPost("api/appointments")]
        public async Task<IActionResult> AddAppoiment([FromBody]AddAppointmentDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _appointmentService.AddAppointment(model));
        }

        [ODataIgnored]
        [HttpPut("api/appointments")]
        public async Task<IActionResult> UpdateAppointment()
        {
            await _appointmentService.TestConcurrency();
            return Ok();
        }
    }
}
