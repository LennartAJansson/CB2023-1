using Builder.Items;

namespace Builder.Builders;

//The 'Builder' class, is abstraction of what needs to be executed by the director in each product
public abstract class CarBuilder
{
    protected readonly Car _car = new();
    public abstract void SetTopSpeed();
    public abstract void SetHorsePower();
    public abstract void SetImpressiveFeature();

    public virtual Car Build() => _car;
}
