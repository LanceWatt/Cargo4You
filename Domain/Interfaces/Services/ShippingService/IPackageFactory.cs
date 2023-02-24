using Domain.Entities;

namespace Domain.Interfaces.Services.ShippingService
{
    public interface IPackageFactory
    {
        Package CreatePackage(decimal weight, decimal length, decimal width, decimal height);
    }
}