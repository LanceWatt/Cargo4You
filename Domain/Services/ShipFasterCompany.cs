using Cargo4You.Domain.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;

public class ShipFasterCompany : CompanyBase
{
    public override EShippingCompany CompanyName { get; } = EShippingCompany.ShipFaster;

    public override decimal MaxWeight { get; } = 30;

    public override decimal MinWeight { get; } = 10;

    public override decimal MaxVolumeCmCubed { get; } = 1700;

    public override decimal MinVolumeCmCubed { get; } = 0;

    public override decimal EvaluateVolumePrice(decimal volume)
    {
        decimal volumePrice;

        if (volume <= 1000)
        {
            volumePrice = 11.99m;
        }
        else if (volume <= 1700)
        {
            volumePrice = 21.99m;
        }
        else
        {
            volumePrice = 36.50m;
        }

        return volumePrice;
    }

    public override decimal EvaluateWeightPrice(decimal weight)
    {
        decimal heightWeightPrice;

        if (weight <= 10)
        {
            heightWeightPrice = 0;
        }
        else if (weight <= 15)
        {
            heightWeightPrice = 16.50m;
        }
        else if (weight <= 25)
        {
            heightWeightPrice = 36.50m;
        }
        else
        {
            decimal additionalCostPerKilo = Math.Ceiling(0.417m * (weight - 25));
            heightWeightPrice = 40.00m + additionalCostPerKilo;
        }

        return heightWeightPrice;
    }
}