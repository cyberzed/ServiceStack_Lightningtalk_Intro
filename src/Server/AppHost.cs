using Funq;
using ServiceStack.Common;
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
			          		EnableFeatures = Feature.All
			          			.Remove(Feature.Jsv)
			          			.Remove(Feature.Soap11)
			          			.Remove(Feature.Soap12)
			          			.Remove(Feature.Xml)
			          	});
		}
	}
}