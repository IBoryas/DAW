﻿namespace DAW.Common.DTOs.Client
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string CompanyRepresentative { get; set; }
        public string VendorRepresentative { get; set; }
        public List<string> Deals { get; set; }
    }
}
