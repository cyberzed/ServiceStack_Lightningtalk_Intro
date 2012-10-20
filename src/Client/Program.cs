using DTO.Requests;
using ServiceStack.ServiceClient.Web;

namespace Client
{
	internal class Program
	{
		private static void Main()
		{
			const string serverPath = "http://localhost/";

			var client = new JsonServiceClient(serverPath);

			var regions = client.Get(new Distilleries());

			var distilleries = client.Get(new Distilleries {Region = regions[0].Region});
		}
	}
}