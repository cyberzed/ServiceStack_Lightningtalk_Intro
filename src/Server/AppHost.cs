using Funq;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;

namespace Server
{
	public class AppHost : AppHostHttpListenerBase
	{
		public AppHost() : base("ServiceStack Demo", typeof (AppHost).Assembly)
		{
			LogManager.LogFactory = new NLogFactory();
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