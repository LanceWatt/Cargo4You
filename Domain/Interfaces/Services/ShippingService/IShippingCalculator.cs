using Cargo4You.Domain.Interfaces;
using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICheapestCompanyCalculator
    {
        QuoteResponseData GetCheapestCompany(Package package);

        List<IParcelSpecificationService> ShippingCompanies { get; set; }
    }
}