using ApointmentService;
using ApointmentService.Interface;
using ApointmentService.Repository;
using ApointmentService.RequestModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI;
using WebAPI.Controllers;
using Assert = NUnit.Framework.Assert;
namespace TestUnit
{
    [TestClass]
    public class Tests
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public Tests(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            //_auth = new Auth();
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestMethod]
        public void AppointmentReportTest()
        {
            var testAppointmentData = GetTestAppointmentData();
            DateTime date = DateTime.Now;
            string dates = date.ToShortDateString();
            dates = "12/05/2024";
            date = Convert.ToDateTime(dates);
            AppointmentController controller = new AppointmentController(_appointmentRepository);
            var result = controller.AppointmentReport(date);
            Assert.AreEqual(testAppointmentData, result);
        }
        private List<AppointmentModel> GetTestAppointmentData()
        {
            var testAppointment = new List<AppointmentModel>();
            testAppointment.Add(new AppointmentModel { customer_id = "1", customer_name = "eva", appointment_date = Convert.ToDateTime("12/05/2024") });

            return testAppointment;
        }
    }
}