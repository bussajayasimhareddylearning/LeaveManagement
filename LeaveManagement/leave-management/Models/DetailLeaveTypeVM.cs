using System;
using System.ComponentModel.DataAnnotations;

namespace leave_management.Models
{
    public class DetailLeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Date Created")]
        public DateTime? DateCreated { get; set; }
        [Required]
        [Display(Name ="Default Number Of Days")]
        [Range(1,25,ErrorMessage ="please enter a valid value")]
        [DataType(DataType.Text)]
        public int DefaultDays { get; set; }
    }
  
}
