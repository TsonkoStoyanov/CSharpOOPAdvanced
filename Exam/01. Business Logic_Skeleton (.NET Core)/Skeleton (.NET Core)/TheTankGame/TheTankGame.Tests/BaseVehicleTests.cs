//using TheTankGame.Entities.Miscellaneous;
//using TheTankGame.Entities.Miscellaneous.Contracts;
//using TheTankGame.Entities.Parts;
//using TheTankGame.Entities.Vehicles;
//using TheTankGame.Entities.Parts.Contracts;
//using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class BaseVehicleTests
    {

        [Test]
        public void ValidateVehicleConstructor()
        {
            Type type = typeof(BaseVehicle);

            var flags = BindingFlags.NonPublic | BindingFlags.Instance;

            var constructor = type.GetConstructors(flags).FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, "Constructor doesn't exists");

            var constructorsParams = constructor.GetParameters();

            Assert.That(constructorsParams[0].ParameterType, Is.EqualTo(typeof(string)));
            Assert.That(constructorsParams[1].ParameterType, Is.EqualTo(typeof(double)));
            Assert.That(constructorsParams[2].ParameterType, Is.EqualTo(typeof(decimal)));
            Assert.That(constructorsParams[3].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructorsParams[4].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructorsParams[5].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructorsParams[6].ParameterType, Is.EqualTo(typeof(IAssembler)));

        }

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Vanguard",
                "Revenger"
            };

            foreach (var currentType in types)
            {
                var resulType = currentType.GetType();

                Assert.That(resulType, Is.Not.Null, $"{currentType} doesn't exists");
            }
        }

        [Test]
        public void ValidateVehicleChildClasses()
        {
            Type baseVehicle = typeof(BaseVehicle);

            var derivedTypes = new[]
            {
                typeof(Vanguard),
                typeof(Revenger)

            };

            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(baseVehicle), $"{derivedType} doesn't inherit {baseVehicle}!");
            }
        }

        [Test]
        public void ValidateVehicleIsAbstract()
        {
            Type vehicle = typeof(BaseVehicle);
            Assert.That(vehicle.IsAbstract, $"Vehicle class must be abstract!");
        }

        [Test]
        public void ValidateVehicleFields()
        {
            Type vehicle = typeof(BaseVehicle);

            var model = vehicle.GetField("model", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(model, Is.Not.Null, $"Invalid field");

            var weight = vehicle.GetField("weight", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(weight, Is.Not.Null, $"Invalid field");

            var price = vehicle.GetField("price", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(price, Is.Not.Null, $"Invalid field");

            var attack = vehicle.GetField("attack", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(attack, Is.Not.Null, $"Invalid field");

            var defense = vehicle.GetField("defense", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(defense, Is.Not.Null, $"Invalid field");

            var hitPoints = vehicle.GetField("hitPoints", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.That(hitPoints, Is.Not.Null, $"Invalid field");
        }

        [Test]
        public void ValidateVehicleProperties()
        {
            Type vehicle = typeof(BaseVehicle);
            var actualProperties = vehicle.GetProperties();

            var expectedProperties = new Dictionary<string, Type>
            {
                { "Model", typeof(string) },
                { "Weight", typeof(double) },
                { "Price", typeof(decimal) },
                { "Attack", typeof(int) },
                { "Defense", typeof(int) },
                { "HitPoints", typeof(int) },
                { "TotalWeight", typeof(double) },
                { "TotalPrice", typeof(decimal)},
                { "TotalAttack", typeof(long) },
                { "TotalDefense", typeof(long)},
                { "TotalHitPoints", typeof(long)},
                { "Parts", typeof(IEnumerable<IPart>)},

            };

            foreach (var actualProperty in actualProperties)
            {
                var isValidProperty = expectedProperties.Any(x => x.Key == actualProperty.Name && actualProperty.PropertyType == x.Value);

                Assert.That(isValidProperty, $"{actualProperty.Name} doesn't exists!");
            }
        }

        //Vehicle Vanguard SA-203 100 300 1000 450 2000
        //Part SA-203 Arsenal Cannon-KA2 300 500 450

        [Test]
        public void ValidateAddArsenal()
        {
            IVehicle vehicle = new Vanguard("SA-203", 100.00, 300m, 1000, 450, 2000, new VehicleAssembler());

            IPart arsenalPart = new ArsenalPart("Cannon-KA2", 300, 500, 450);

            IPart shellPart = new ShellPart("Shields-PI1", 200, 1000, 750);

            IPart endurancePart = new EndurancePart("endurance", 200, 1000, 750);

            vehicle.AddArsenalPart(arsenalPart);
            vehicle.AddShellPart(shellPart);
            vehicle.AddEndurancePart(endurancePart);


            Assert.That(vehicle.Parts.ToList().Count == 3);
        }

        [Test]
        public void ValidateCalculatedProperty()
        {
            IVehicle vehicle = new Vanguard("SA-203", 100.00, 300m, 1000, 450, 2000, new VehicleAssembler());

            IPart arsenalPart = new ArsenalPart("Cannon-KA2", 300, 500, 450);

            IPart shellPart = new ShellPart("Shields-PI1", 200, 1000, 750);

            IPart endurancePart = new EndurancePart("endurance", 200, 1000, 750);


            double actualResultTotalWeight = 100;

            Assert.AreEqual(actualResultTotalWeight, vehicle.TotalWeight);

            decimal actualResultTotalPrice = 300;

            Assert.AreEqual(actualResultTotalPrice, vehicle.TotalPrice);

            long actualResultTotalAttack = 1000;

            Assert.AreEqual(actualResultTotalAttack, vehicle.TotalAttack);

            long actualResultTotalDefense = 450;

            Assert.AreEqual(actualResultTotalDefense, vehicle.TotalDefense);

            long actualResultTotalHitPoints = 2000;

            Assert.AreEqual(actualResultTotalHitPoints, vehicle.TotalHitPoints);

        }

        [Test]
        public void ValidateExeption()
        {
            Assert.Throws<ArgumentException>(() => new Vanguard(" ", 0, 0, 0, 0, 0, new VehicleAssembler()), "Model cannot be null or white space!");
            Assert.Throws<ArgumentException>(() => new Vanguard("U2", -1, 0, 0, 0, 0, new VehicleAssembler()), "Weight cannot be less or equal to zero!");
            Assert.Throws<ArgumentException>(() => new Vanguard("U2", 100, 0, 0, 0, 0, new VehicleAssembler()), "Price cannot be less or equal to zero!");
            Assert.Throws<ArgumentException>(() => new Vanguard("U2", 100, 100, -1, -1, -1, new VehicleAssembler()), "Attack cannot be less than zero!");
            Assert.Throws<ArgumentException>(() => new Vanguard("U2", 100, 100, 100, -1, -1, new VehicleAssembler()), "Defense cannot be less than zero!");
            Assert.Throws<ArgumentException>(() => new Vanguard("U2", 100, 100, 100, 100, -1, new VehicleAssembler()), "HitPoints cannot be less than zero!");

        }


        [Test]
        public void ValidateToString()
        {

            IVehicle vehicle = new Vanguard("SA-203", 100.00, 300m, 1000, 450, 2000, new VehicleAssembler());

            IPart arsenalPart = new ArsenalPart("Cannon-KA2", 300, 500, 450);

            IPart shellPart = new ShellPart("Shields-PI1", 200, 1000, 750);

            IPart endurancePart = new EndurancePart("endurance", 200, 1000, 750);

            vehicle.AddArsenalPart(arsenalPart);
            vehicle.AddShellPart(shellPart);
            vehicle.AddEndurancePart(endurancePart);

            string actualResult = vehicle.ToString();
            string expectedResult =
                "Vanguard - SA-203\r\nTotal Weight: 800.000\r\nTotal Price: 2800.000\r\nAttack: 1450\r\nDefense: 1200\r\nHitPoints: 2750\r\nParts: Cannon-KA2, Shields-PI1, endurance";

            Assert.AreEqual(actualResult, expectedResult);

        }
    }
}