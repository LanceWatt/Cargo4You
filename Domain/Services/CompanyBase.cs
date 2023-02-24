using Cargo4You.Domain.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public abstract class CompanyBase : IParcelSpecificationService
    {
        public abstract EShippingCompany CompanyName { get; }

        public abstract decimal MaxWeight { get; }

        public abstract decimal MinWeight { get; }

        public abstract decimal MaxVolumeCmCubed { get; }

        public abstract decimal MinVolumeCmCubed { get; }

        public abstract decimal EvaluateVolumePrice(decimal volume);

        public abstract decimal EvaluateWeightPrice(decimal weight);

        public decimal CalculateRate(Package package)
        {
            decimal weight = package.Weight;
            decimal volume = package.Dimensions.VolumeInCm;

            decimal weightPrice = EvaluateWeightPrice(weight);
            decimal volumePrice = EvaluateVolumePrice(volume);

            return Math.Max(weightPrice, volumePrice);
        }

        public bool CanHandleParcel(Package package)
        {
            decimal weight = package.Weight;
            decimal volume = package.Volume;

            if ((weight >= MinWeight && weight <= MaxWeight) && volume <= MaxVolumeCmCubed)
            {
                return true;
            }

            return false;
        }

    }
}