using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceStack.ServiceHost;

namespace Server.Installers
{
	public class ApiInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromThisAssembly()
					.BasedOn<IService>()
					.WithService
					.DefaultInterfaces()
					.LifestyleSingleton()
				);
		}
	}
}