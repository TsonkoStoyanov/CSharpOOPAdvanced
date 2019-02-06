using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;
using TheTankGame.Entities.Vehicles;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Type vehicleType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            IAssembler assembler = new VehicleAssembler();

            IVehicle vehicle = (IVehicle)Activator.CreateInstance(vehicleType,  model, weight, price, attack, defense, hitPoints, assembler);
            

            return vehicle;
        }
    }
}