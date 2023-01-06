using System.ComponentModel.DataAnnotations;

namespace DAW.Common.DTOs.Employee
{
    public class UpdateEmployeeDto
    { 

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string JobRole { get; set; }

        public int? ProjectId { get; set; }

        [Required]
        public int WorkHours { get; set; }

        [Required]
        public double SalaryPerHour { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
