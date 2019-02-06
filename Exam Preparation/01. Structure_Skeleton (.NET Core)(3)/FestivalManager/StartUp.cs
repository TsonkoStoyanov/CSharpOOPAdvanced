using FestivalManager.Core;

namespace FestivalManager
{
    public static class StartUp
	{
		public static void Main(string[] args)
		{
			var engine = new Engine();
            engine.Run();
		}
	}
}