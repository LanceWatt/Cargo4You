using Cargo4You.Domain.Interfaces;
using Domain.Entities;

namespace Domain.Interfaces.Services.ShippingService
{
    public interface IShippingCompanyFilter
    {
        public List<IParcelSpecificationService> Filter(Package package, List<IParcelSpecificationService> companies);
    }
}