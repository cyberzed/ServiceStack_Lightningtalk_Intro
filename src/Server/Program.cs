using System;

namespace Server
{
	internal class Program
	{
		private static void Main()
		{
			const string serverListeningOn = "http://*:80/";

			var appHost = new AppHost();

			appHost.Init();

			appHost.Start(serverListeningOn);

			Console.WriteLine("Server started, listening on: {0}", serverListeningOn);
		}
	}
}