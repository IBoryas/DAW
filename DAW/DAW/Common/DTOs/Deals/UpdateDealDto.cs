namespace DAW.Common.DTOs.Deals
{
    public class UpdateDealDto
    {
        public int ClientId { get; set; }
        public int PricePerHour { get; set; }
        public int Likelihood { get; set; }
        public DateTime ProspectedStartDate { get; set; }
        public int ProspectedHours { get; set; }
    }
}
