using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; } // Present / Absent
    }
}
