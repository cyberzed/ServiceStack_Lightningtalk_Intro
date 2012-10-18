using System;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Server.DataLoaders;

namespace Server
{
	public class ServiceBootstrapper : IDisposable
	{
		private readonly string serverListeningOn;

		private readonly WindsorContainer windsorContainer;

		public ServiceBootstrapper(string serverListeningOn)
		{
			this.serverListeningOn = serverListeningOn;
			windsorContainer = new WindsorContainer();

			windsorContainer.Install(FromAssembly.InThisApplication());

			var distilleryLoader = windsorContainer.Resolve<DistilleryLoader>();
			var whiskyLoader = windsorContainer.Resolve<WhiskyLoader>();

			distilleryLoader.LoadDistilleries();
			whiskyLoader.LoadWhiskies();
		}

		public void Dispose()
		{
			var appHost = windsorContainer.Resolve<AppHost>();

			appHost.Stop();

			windsorContainer.Dispose();
		}

		public void Run()
		{
			var appHost = windsorContainer.Resolve<AppHost>();

			appHost.Container.Adapter = new WindsorContainerAdapter(windsorContainer);

			appHost.Start(serverListeningOn);
		}
	}
}