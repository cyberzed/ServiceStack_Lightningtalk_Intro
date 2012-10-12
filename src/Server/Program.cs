using System;
using Castle.Windsor;

namespace Server
{
	internal class Program
	{
		private static void Main()
		{
			var container = new WindsorContainer();

			var windsorContainerAdapter = new WindsorContainerAdapter(container);

			const string serverListeningOn = "http://*:80/";

			var appHost = new AppHost();

			appHost.Container.Adapter = windsorContainerAdapter;

			appHost.Init();

			appHost.Start(serverListeningOn);

			Console.WriteLine("Server started, listening on: {0}", serverListeningOn);
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
					break;
				}
			}

			appHost.Stop();

			container.Dispose();
		}
	}
}