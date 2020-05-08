using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Models
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public int NumberOfDays { get; set; }

        public string EmployeeID { get; set; }

        public EmployeeVM Employee { get; set; }

        public int LeaveTypeID { get; set; }

        public DetailLeaveTypeVM LeaveType { get; set; }

        public IEnumerable<SelectListItem>  Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
    }
}
