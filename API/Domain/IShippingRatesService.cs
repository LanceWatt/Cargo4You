using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces.Services.ShippingService
{
    public interface IShippingRatesService
    {
        Task SaveQuoteDataToDatabase(QuoteSubmissionDataDto quoteRequestDto);
        Task<QuoteResponseData> ProcessQuote(ReceiveQuoteEnquiryDto packageInput);
        List<string> GetListOfSuppliers();
    }
}