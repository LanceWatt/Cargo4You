using Domain.Entities;

namespace Domain.Interfaces.Services.ShippingService
{
    public class PackageFactory : IPackageFactory
    {
        public Package CreatePackage(decimal weightInKg, decimal lengthInCm, decimal widthInCm, decimal heightInCm)
        {
            var dimensions = new Dimensions(lengthInCm, widthInCm, heightInCm);
            return new Package(weightInKg, dimensions);
        }
    }
}