using Cargo4You.Domain.Interfaces;

namespace Domain.Interfaces.Services.ShippingService
{
    public class ShippingCompanyProvider : IShippingCompanyProvider
    {
        public List<IParcelSpecificationService> ShippingCompanies { get; set; }

        public ShippingCompanyProvider()
        {
            ShippingCompanies = new List<IParcelSpecificationService>()
        {
            new Cargo4YouCompany(),
            new ShipFasterCompany(),
            new MaltaShipCompany()
        };
        }
    }
}