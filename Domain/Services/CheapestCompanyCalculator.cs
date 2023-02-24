using Cargo4You.Domain.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class CheapestCompanyCalculator : ICheapestCompanyCalculator
    {
        private List<IParcelSpecificationService> _shippingCompanies { get; set; }

        public QuoteResponseData GetCheapestCompany(Package package)
        {
            decimal cheapestCost = decimal.MaxValue;
            string cheapestCompany = "";
            QuoteResponseData quoteResponseData = new QuoteResponseData();

            foreach (var company in _shippingCompanies)
            {
                if (company.CanHandleParcel(package))
                {
                    quoteResponseData.Found = true;
                    decimal cost = company.CalculateRate(package);
                    if (cost < cheapestCost)
                    {
                        cheapestCost = cost;
                        cheapestCompany = company.CompanyName.ToString();
                    }
                }
            }

            quoteResponseData.MostCompetitiveRate = cheapestCost;
            quoteResponseData.CompanySupplier = cheapestCompany;
            return quoteResponseData;
        }

        public List<IParcelSpecificationService> ShippingCompanies
        {
            get { return _shippingCompanies; }
            set { _shippingCompanies = value; }
        }
    }
}