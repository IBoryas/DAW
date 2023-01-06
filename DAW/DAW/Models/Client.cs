namespace DAW.Models
{
    public class Client : BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string CompanyRepresentative { get; set; }
        public string VendorRepresentative { get; set; }
        public virtual List<Deal> Deals { get; set; }
    }
}
