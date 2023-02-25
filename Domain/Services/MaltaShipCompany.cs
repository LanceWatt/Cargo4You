using Cargo4You.Domain.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;

public class MaltaShipCompany : CompanyBase
{
    public override EShippingCompany CompanyName { get; } = EShippingCompany.MaltaShip;

    public override decimal MaxWeight { get; } = 10;

    public override decimal MinWeight { get; } = 10;

    public override decimal MaxVolumeCmCubed { get; } = 500;

    public override decimal MinVolumeCmCubed { get; } = 0;

    public override decimal EvaluateWeightPrice(decimal weight)
    {
        decimal weightPrice = 0;

        if (weight > 10 && weight <= 20)
        {
            weightPrice = 16.99m;
        }
        else if (weight > 20 && weight <= 30)
        {
            weightPrice = 33.99m;
        }
        else if (weight > 30)
        {
            decimal additionalCostPerKilo = ((weight - 25) * 0.41m);
            weightPrice = 43.99m + additionalCostPerKilo;
        }

        return weightPrice;
    }

    public override decimal EvaluateVolumePrice(decimal volume)
    {
        decimal volumePrice = 0;

        if (volume <= 1000)
        {
            volumePrice = 9.50m;
        }
        else if (volume > 1000 && volume <= 2000)
        {
            volumePrice = 19.50m;
        }
        else if (volume > 2000 && volume <= 5000)
        {
            volumePrice = 48.50m;
        }
        else if (volume > 5000)
        {
            volumePrice = 147.50m;
        }

        return volumePrice;
    }
}