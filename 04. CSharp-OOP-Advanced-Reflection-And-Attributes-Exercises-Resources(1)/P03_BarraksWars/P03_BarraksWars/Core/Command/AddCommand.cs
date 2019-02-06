using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Atributes;

namespace _03BarracksFactory.Core.Command
{
    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

      
        public AddCommand(string[] data)
            : base(data)
        {
           
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}