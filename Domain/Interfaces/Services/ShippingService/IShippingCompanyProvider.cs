using Cargo4You.Domain.Interfaces;

namespace Domain.Interfaces.Services.ShippingService
{
    public interface IShippingCompanyProvider
    {
        List<IParcelSpecificationService> ShippingCompanies { get; set; }
    }
}