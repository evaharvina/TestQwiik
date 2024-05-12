using ApointmentService.Context;
using ApointmentService.Interface;
using ApointmentService.RequestModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApointmentService.Repository
{
    public class ApointmentRepository : IAppointmentRepository
    {

        private readonly TESTContext _context;
        public ApointmentRepository()
        {
            _context = new TESTContext();
        }
        public object InterfaceAppointmentReport(DateTime date)
        {
            if (date == null || date.ToShortDateString() == "01/01/0001")
            {
                var result = _context.TrxAppointments.OrderBy(p => p.AppointmentDate).OrderByDescending(p => p.CreatedDate);
                return result;
            } else
            {
                var result = getAppointmentByDate(date);
                return result;
            }
        }

        public object InterfaceInsertAppointment(AppointmentModel appointmentmodel)
        {
            TrxAppointment trxappointment = new TrxAppointment();
            int maxnumber = getMaxNumber(appointmentmodel.appointment_date);
            int maxappointment = getNumberAppointmentByDate(appointmentmodel.appointment_date);
            DateTime appointment_date = DateTime.Now;
            if (maxappointment >= maxnumber)
            {
                appointment_date = appointmentmodel.appointment_date.AddDays(1);
            } else
            {
                appointment_date = appointmentmodel.appointment_date;
            }
            if (isHoliday(appointmentmodel.appointment_date) == false)
            {
                trxappointment.CustomerId = appointmentmodel.customer_id;
                trxappointment.CustomerName = appointmentmodel.customer_name;
                trxappointment.AppointmentDate = appointment_date;//appointmentmodel.appointment_date;
                trxappointment.CreatedDate = DateTime.Now;
                _context.Add(trxappointment);
                _context.SaveChanges();
                return trxappointment;
            } else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public object InterfaceInsertHoliday(HolidayModel holidaymodel)
        {
            MstHoliday mstholiday = new MstHoliday();
            mstholiday.HolidayName = holidaymodel.holiday_name;
            mstholiday.HolidayDate = holidaymodel.holiday_date;
            mstholiday.IsActive = true;
            mstholiday.IsDeleted = false;
            mstholiday.CreatedDate = DateTime.Now;
            _context.Add(mstholiday);
            _context.SaveChanges();
            return mstholiday;
        }

        public object InterfaceInsertMaxAppointment(MaxAppointmentModel maxappointmentmodel)
        {
            MstMaxAppointment mstmaxappointment = new MstMaxAppointment();
            mstmaxappointment.StartDate = maxappointmentmodel.start_date;
            mstmaxappointment.EndDate = maxappointmentmodel.end_date;
            mstmaxappointment.MaxNumber = maxappointmentmodel.max_number;
            mstmaxappointment.IsActive = true;
            mstmaxappointment.IsDeleted = false;
            mstmaxappointment.CreatedDate = DateTime.Now;
            _context.Add(mstmaxappointment);
            _context.SaveChanges();
            return mstmaxappointment;
        }

        private bool isHoliday(DateTime date)
        {
            var mstHoliday = from p in _context.MstHolidays
                                    where p.HolidayDate == date select p;
            if (mstHoliday.Any() )
            {
                return true;
            } else
            {
                return false;
            }
        }
        private int getMaxNumber(DateTime date)
        {
            var mstMaxNumber = _context.MstMaxAppointments.FirstOrDefault(p => p.StartDate <= date.Date && p.EndDate >= date.Date);
            if (mstMaxNumber == null)
            {
                return 5;
            }
            else
            {
                return Convert.ToInt32(mstMaxNumber.MaxNumber);
            }
        }
        private int getNumberAppointmentByDate(DateTime date)
        {
            var numberAppointment = from p in _context.TrxAppointments
                             where p.AppointmentDate == date
                             select p;
            if (numberAppointment == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(numberAppointment.Count());
            }
        }
        private object getAppointmentByDate(DateTime date)
        {
            var Appointment = from p in _context.TrxAppointments
                                    where p.AppointmentDate == date
                                    select p;
            return Appointment;
        }
    }
}
