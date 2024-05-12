using System;
using System.Collections.Generic;

namespace ApointmentService.Context
{
    public partial class MstHoliday
    {
        public long HolidayId { get; set; }
        public string? HolidayName { get; set; }
        public DateTime? HolidayDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
