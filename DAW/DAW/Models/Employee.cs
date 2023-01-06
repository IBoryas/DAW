namespace DAW.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobRole { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int WorkHours { get; set; }
        public double SalaryPerHour { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
