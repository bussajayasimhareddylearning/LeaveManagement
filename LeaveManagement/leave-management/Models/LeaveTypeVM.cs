using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    public class DetailLeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
