using System;
using System.Collections.Generic;

namespace ApointmentService.Context
{
    public partial class TrxAppointment
    {
        public long AppointmentId { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
