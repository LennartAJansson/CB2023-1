namespace Builder.Builders;

public class SuperCarBuilder : CarBuilder
{
    public override void SetHorsePower() => _car.HorsePower = 1640;

    public override void SetImpressiveFeature() => _car.MostImpressiveFeature = "Can Fly";

    public override void SetTopSpeed() => _car.TopSpeedMPH = 600;
}
