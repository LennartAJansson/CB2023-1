using System;
using System.Collections.Generic;

namespace Builder
{
    //Builder pattern is quite similar to AbstractFactory pattern
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builders = new List<CarBuilder> { new SuperCarBuilder(), new NotSoSuperCarBuilder() };

            foreach (var builder in builders)
            {
                var factory = new CarFactory();
                var car = factory.Build(builder);
                Console.WriteLine($"The car requested by " +
                    $"{builder.GetType().Name}: \n" +
                    $"------------------------------------------\n" +
                    $"HorsePowers: {car.HorsePower}\n" +
                    $"TopSpeed   : {car.TopSpeedMPH} MPH\n" +
                    $"Feature    : {car.MostImpressiveFeature}\n\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }

    //The 'Product' class
    public class Car
    {
        public int TopSpeedMPH { get; set; }
        public int HorsePower { get; set; }
        public string MostImpressiveFeature { get; set; }
    }

    //The 'Builder' class, is abstraction of what needs to be executed by the director in each product
    public abstract class CarBuilder
    {
        protected readonly Car _car = new Car();
        public abstract void SetTopSpeed();
        public abstract void SetHorsePower();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar()
        {
            return _car;
        }
    }

    //The 'Director' class
    public class CarFactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetTopSpeed();
            builder.SetHorsePower();
            builder.SetImpressiveFeature();
            return builder.GetCar();
        }
    }

    public class NotSoSuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 120;
        }

        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Has Air Conditioning";
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 70;
        }
    }

    public class SuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 1640;
        }

        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Can Fly";
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 600;
        }
    }
}
