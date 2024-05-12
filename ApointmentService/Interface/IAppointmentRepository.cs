using ApointmentService.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApointmentService.Interface
{
    public interface IAppointmentRepository
    {
        object InterfaceAppointmentReport(DateTime date);
        object InterfaceInsertHoliday(HolidayModel holidaymodel);
        object InterfaceInsertMaxAppointment(MaxAppointmentModel maxappointmentmodel);
        object InterfaceInsertAppointment(AppointmentModel appointmentmodel);
    }
}
