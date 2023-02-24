using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class QuoteSubmissionDataDto
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal ParcelWidth { get; set; }
        public decimal ParcelHeight { get; set; }
        public decimal ParcelLength { get; set; }
        public decimal ParcelWeight { get; set; }
        public string CompanySupplier { get; set; }
        public bool CompanyFound { get; set; }
        public decimal MostCompetitiveRate { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
    }
}