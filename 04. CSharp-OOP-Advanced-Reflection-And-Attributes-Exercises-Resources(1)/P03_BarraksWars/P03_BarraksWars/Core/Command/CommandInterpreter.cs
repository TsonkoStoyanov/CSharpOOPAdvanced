using System;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Atributes;

namespace _03BarracksFactory.Core.Command
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
           Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            IExecutable executable =
                (IExecutable) Activator.CreateInstance(type, new object[] {data});
            this.InjectDependencies(executable);
            return executable;

        }

        private void InjectDependencies(IExecutable executable)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;

            FieldInfo[] commandFields = executable.GetType().GetFields(flags).Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null).ToArray();

            FieldInfo[] interpreterFields = this.GetType().GetFields(flags);

            foreach (FieldInfo fieldOfCommand in commandFields)
            {
                if (interpreterFields.Any(i => i.FieldType == fieldOfCommand.FieldType))
                {
                    fieldOfCommand.SetValue(executable, interpreterFields.First(i=> i.FieldType == fieldOfCommand.FieldType).GetValue(this));
                }
            }
        }
    }
}