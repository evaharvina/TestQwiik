namespace ApointmentService.RequestModel
{
    public class MaxAppointmentModel
    {
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int max_number { get; set; }
    }
}
