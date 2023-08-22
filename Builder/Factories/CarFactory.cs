using Builder.Builders;
using Builder.Items;

namespace Builder.Factories;

public class CarFactory
{
    public Car Build(CarBuilder builder)
    {
        builder.SetTopSpeed();
        builder.SetHorsePower();
        builder.SetImpressiveFeature();
        return builder.Build();
    }
}
