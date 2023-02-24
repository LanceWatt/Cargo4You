using Cargo4You.Domain.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces.Services.ShippingService
{
    public class ViableShippingCompanyFilter : IShippingCompanyFilter
    {
        public List<IParcelSpecificationService> Filter(Package package, List<IParcelSpecificationService> companies)
        {
            return companies.Where(c => c.CanHandleParcel(package)).ToList();
        }
    }
}