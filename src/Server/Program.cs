using System;

namespace Server
{
	internal class Program
	{
		private static void Main()
		{
			const string serverListeningOn = "http://*:80/";

			var bootStrap = new ServiceBootstrapper(serverListeningOn);

			bootStrap.Run();

			Console.WriteLine("Server started, listening on {0}", serverListeningOn);
			Console.WriteLine("Press q to quit");

			while (true)
			{
				var input = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(input))
				{
					continue;
				}

				if (input.Equals("q", StringComparison.OrdinalIgnoreCase))
				{
					bootStrap.Dispose();

					break;
				}
			}
		}
	}
}