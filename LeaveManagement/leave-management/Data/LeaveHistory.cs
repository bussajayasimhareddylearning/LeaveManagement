using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestingEmployeeID")]
        public Employee RequestingEmployee { get; set; }
        [ForeignKey("LeaveTypeID")]
        public LeaveType LeaveType { get; set; }
        [ForeignKey("ApprovedByID")]
        public Employee ApprovedBy { get; set; }


        public string RequestingEmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
        public string ApprovedByID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime DateActioned { get; set; }

        public bool? Approved { get; set; }
    }
}
