using Builder.Builders;
using Builder.Factories;
using Builder.Items;

List<CarBuilder> builders = new() { new SuperCarBuilder(), new NotSoSuperCarBuilder() };
CarFactory factory = new();

foreach (CarBuilder builder in builders)
{
    Car car = factory.Build(builder);
    Console.WriteLine($"The car requested by {builder.GetType().Name}:");
    Console.WriteLine($"------------------------------------------");
    Console.WriteLine($"HorsePowers: {car.HorsePower}");
    Console.WriteLine($"TopSpeed   : {car.TopSpeedMPH} MPH");
    Console.WriteLine($"Feature    : {car.MostImpressiveFeature}");
}

