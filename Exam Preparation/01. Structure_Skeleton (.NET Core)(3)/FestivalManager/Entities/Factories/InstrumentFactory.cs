namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string istrumenttype)
		{
		    var type = Assembly.GetCallingAssembly().GetTypes().First(t => t.Name == istrumenttype);

		    return (IInstrument) Activator.CreateInstance(type);
		}
	}
}