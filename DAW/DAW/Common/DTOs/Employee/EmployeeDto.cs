using DAW.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW.Common.DTOs.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobRole { get; set; }
        public string ProjectName { get; set; }
    }
}
