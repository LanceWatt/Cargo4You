using Cargo4You.Domain.Interfaces;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;

public class Cargo4YouCompany : CompanyBase
{
    public override EShippingCompany CompanyName { get; } = EShippingCompany.Cargo4You;

    public override decimal MaxWeight { get; } = 20;

    public override decimal MinWeight { get; } = 0;

    public override decimal MaxVolumeCmCubed { get; } = 2000;

    public override decimal MinVolumeCmCubed { get; } = 0;

    public override decimal EvaluateWeightPrice(decimal weight)
    {
        decimal weightPrice = 0;

        if (weight <= 2)
        {
            weightPrice = 15.00m;
        }
        else if (weight > 2 && weight <= 15)
        {
            weightPrice = 18.00m;
        }
        else if (weight > 15 && weight <= 20)
        {
            weightPrice = 35;
        }

        return weightPrice;
    }

    public override decimal EvaluateVolumePrice(decimal volume)
    {
        decimal volumePrice = 0;

        if (volume <= 1000)
        {
            volumePrice = 10;
        }
        else if (volume > 1000 && volume <= 2000)
        {
            volumePrice = 20;
        }
        return volumePrice;
    }
}