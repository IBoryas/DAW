namespace DAW.Common.DTOs.Deals
{
    public class CreateDealDto
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int PricePerHour { get; set; }
        public int Likelihood { get; set; }
        public DateTime ProspectedStartDate { get; set; }
        public int ProspectedHours { get; set; }
    }
}
