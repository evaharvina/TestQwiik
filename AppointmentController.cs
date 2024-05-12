using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ApointmentService.RequestModel;
using ApointmentService.Context;
using ApointmentService.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly Auth _auth;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _auth = new Auth();
        }

        [HttpGet("AppointmentReport")]
        public object AppointmentReport(DateTime date)
        {
            if (_auth.AuthenticateUser(Request))
            {
              return _appointmentRepository.InterfaceAppointmentReport(date);
            }
            else
            {
              return BadRequest(new { message = "Unauthorized" });
            }
        }

        [HttpPost("InsertHoliday")]
        public object InsertHoliday(HolidayModel holiday)
        {

            if (_auth.AuthenticateUser(Request))
            {
              return _appointmentRepository.InterfaceInsertHoliday(holiday);
            } else
            {
                return BadRequest(new { message = "Unauthorized" });
            }
        }

        [HttpPost("InsertMaxAppointment")]
        public object InsertMaxAppointment(MaxAppointmentModel maxappointment)
        {
            if (_auth.AuthenticateUser(Request))
            {
              return _appointmentRepository.InterfaceInsertMaxAppointment(maxappointment);
            }
            else
            {
                return BadRequest(new { message = "Unauthorized" });
            }
        }

        [HttpPost("InsertAppointment")]
        public object InsertAppointment(AppointmentModel appointment)
        {
            if (_auth.AuthenticateUser(Request))
            {
              return _appointmentRepository.InterfaceInsertAppointment(appointment);
            }
            else
            {
                return BadRequest(new { message = "Unauthorized" });
            }
        }
    }
}
