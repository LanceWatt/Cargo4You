namespace Domain.Dtos
{
    public class ProcessedQuoteDto
    {
        public string CheapestCompanyName { get; set; }
        public decimal Rate { get; set; }
        public bool CompanyFound { get; set; }
        
    }
}