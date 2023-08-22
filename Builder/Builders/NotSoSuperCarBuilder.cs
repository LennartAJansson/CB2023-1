namespace Builder.Builders;

public class NotSoSuperCarBuilder : CarBuilder
{
    public override void SetHorsePower() => _car.HorsePower = 120;

    public override void SetImpressiveFeature() => _car.MostImpressiveFeature = "Has Air Conditioning";

    public override void SetTopSpeed() => _car.TopSpeedMPH = 70;
}
