using Domain.Dtos;
using Domain.Interfaces.Services.ShippingService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    public class ShippingRatesController : BaseAPIController
    {
        private DataContext _context;
        private readonly IShippingRatesService _shippingRatesService;

        public ShippingRatesController(DataContext context, IShippingRatesService shippingRatesService)
        {
            _shippingRatesService = shippingRatesService;
            _context = context;
        }

        // Receive the quote specifications from the client and return the processed rate 
        [HttpPost]
        public async Task<ActionResult<QuoteResponseData>> CalculateShippingRate([FromBody] ReceiveQuoteEnquiryDto newQuoteEnqiryDto)
        {
            QuoteResponseData quoteResponseData = await _shippingRatesService.ProcessQuote(newQuoteEnqiryDto);

            return quoteResponseData;
        }

        // Provide the client with a list of potential suppliers
        [HttpGet]
        public List<string> GetListOfSuppliers()
        {
            var listOfSuppliers = _shippingRatesService.GetListOfSuppliers();
            return listOfSuppliers;
        }

    }
}
