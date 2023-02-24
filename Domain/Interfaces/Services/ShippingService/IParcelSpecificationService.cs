using Domain;
using Domain.Entities;
using Domain.Services;

namespace Cargo4You.Domain.Interfaces
{
    public interface IParcelSpecificationService
    {
        EShippingCompany CompanyName { get; }
        decimal CalculateRate(Package package);
        bool CanHandleParcel(Package package);
    }
}