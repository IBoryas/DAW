namespace DAW.Models
{
    public class Deal : BaseEntity
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int PricePerHour { get; set; }
        public int Likelihood { get; set; }
        public DateTime ProspectedStartDate { get; set; }
        public int ProspectedHours { get; set; }
    }
}
