using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Server.DataLoaders;
using Server.Repositories;

namespace Server.Installers
{
	public class DataInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromAssemblyContaining<DistilleryLoader>()
					.InSameNamespaceAs<DistilleryLoader>()
					.LifestyleTransient()
				);

			container.Register(
				Classes.FromAssemblyContaining<DistilleryRepository>()
					.InSameNamespaceAs<DistilleryRepository>()
					.LifestyleSingleton()
				);
		}
	}
}