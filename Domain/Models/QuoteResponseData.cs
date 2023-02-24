using System;

namespace Domain.Models
{
    public class QuoteResponseData
    {
        public bool Found { get; set; }
        public decimal MostCompetitiveRate { get; set; }
        public string CompanySupplier { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
    }
}