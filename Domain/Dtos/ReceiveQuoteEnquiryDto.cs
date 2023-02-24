

namespace Domain.Dtos
{
    public class ReceiveQuoteEnquiryDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal WidthInCm { get; set; }
        public decimal HeightInCm { get; set; }
        public decimal LengthInCm { get; set; }
        public decimal WeightinKg { get; set; }
    }
}