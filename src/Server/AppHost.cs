using Funq;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace Server
{
	public class AppHost : AppHostBase
	{
		public AppHost() : base("ServiceStack Demo", typeof (AppHost).Assembly)
		{
		}

		public override void Configure(Container container)
		{
			SetConfig(new EndpointHostConfig
			          	{
			          		EnableFeatures = Feature.Json
			          	});
		}
	}
}