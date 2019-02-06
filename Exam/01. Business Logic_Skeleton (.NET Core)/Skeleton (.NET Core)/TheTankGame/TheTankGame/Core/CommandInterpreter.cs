using System.Linq;

namespace TheTankGame.Core
{
    using System.Collections.Generic;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> input)
        {
            string command = input[0];
            IList<string> parameters = input.Skip(1).ToList();

            //string result = string.Empty;

            //switch (command)
            //{
            //    case "Vehicle":
            //        result = this.tankManager.AddVehicle(inputParameters);
            //        break;
            //    case "Part":
            //        result = this.tankManager.AddPart(inputParameters);
            //        break;
            //    case "Inspect":
            //        result = this.tankManager.Inspect(inputParameters);
            //        break;
            //    case "Battle":
            //        result = this.tankManager.Battle(inputParameters);
            //        break;
            //    case "Terminate":
            //        result = this.tankManager.Terminate(inputParameters);
            //        break;
            //}

            //return result;

            string result;

            var tankCommandType = this.tankManager.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name.Contains(command));
            ;
            result = (string)tankCommandType.Invoke(this.tankManager, new object[] { parameters });
            
            return result;
        }
    }
}