using API.Domain;
using AutoMapper;
using Cargo4You.Domain.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Persistence.Data;

namespace Domain.Interfaces.Services.ShippingService
{
    public class ShippingRatesService : IShippingRatesService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICheapestCompanyCalculator _cheapestCompanyCalculator;
        private readonly IQuoteDataRepository _quoteDataRepository;
        private readonly IPackageFactory _packageFactory;
        private readonly IShippingCompanyFilter _shippingCompanyFilter;
        private readonly IShippingCompanyProvider _shippingCompanyProvider;

        public ShippingRatesService(
        DataContext context,
        IMapper mapper,
        ICheapestCompanyCalculator cheapestCompanyCalculator,
        IQuoteDataRepository quoteDataRepository,
        IPackageFactory packageFactory,
        IShippingCompanyFilter shippingCompanyFilter,
        IShippingCompanyProvider shippingCompanyProvider
        )
        {
            _context = context;
            _mapper = mapper;
            _cheapestCompanyCalculator = cheapestCompanyCalculator;
            _quoteDataRepository = quoteDataRepository;
            _packageFactory = packageFactory;
            _shippingCompanyFilter = shippingCompanyFilter;
            _shippingCompanyProvider = shippingCompanyProvider;
        }

        public async Task<QuoteResponseData> ProcessQuote(ReceiveQuoteEnquiryDto newQuoteEnqiryDto)
        {
            var quoteEnquiryDto = newQuoteEnqiryDto;

            // Work out dimensions and volume and store in the package
            var package = _packageFactory.CreatePackage(newQuoteEnqiryDto.WeightinKg, newQuoteEnqiryDto.LengthInCm, newQuoteEnqiryDto.WidthInCm, newQuoteEnqiryDto.HeightInCm);

            // Filter fore viable companies based on package data
            var allShippingCompanies = _shippingCompanyProvider.ShippingCompanies;
            var qualifiedShippingCompanies = _shippingCompanyFilter.Filter(package, allShippingCompanies);

            // Work out the cheapest supplier based on all qualifying suppliers 
            _cheapestCompanyCalculator.ShippingCompanies = qualifiedShippingCompanies;
            var quoteResponseData = _cheapestCompanyCalculator.GetCheapestCompany(package);

            // Add the processed response data to the quoteRequestDataDto, to send complete data to the database
            var quoteSubmissionDataDto = _mapper.Map<QuoteSubmissionDataDto>(quoteEnquiryDto);
            quoteSubmissionDataDto.DateAndTimeOfOrder = DateTime.Now;

            // Combine the raw and processed data
            quoteSubmissionDataDto = _mapper.Map(quoteResponseData, quoteSubmissionDataDto);
            await SaveQuoteDataToDatabase(quoteSubmissionDataDto);

            return quoteResponseData;
        }

        public async Task SaveQuoteDataToDatabase(QuoteSubmissionDataDto quoteDataDto)
        {
            var quoteRequestData = _mapper.Map<QuoteSubmissionData>(quoteDataDto);
            var result = await _quoteDataRepository.AddQuoteRequestData(quoteRequestData);

            if (result == false)
            {
                throw new Exception("Error saving changes to database.");
            }
            await _context.SaveChangesAsync();
        }

        public List<string> GetListOfSuppliers()
        {
            List<string> listOfCompanies = new List<string>();
            var allShippingCompanies = _shippingCompanyProvider.ShippingCompanies;
            foreach (IParcelSpecificationService company in allShippingCompanies)
            {
                listOfCompanies.Add(company.CompanyName.ToString());
            }
            return listOfCompanies;
        }



    }
}