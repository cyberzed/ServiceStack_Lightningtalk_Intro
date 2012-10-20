using DTO;
using ServiceStack.ServiceClient.Web;

namespace Client
{
	internal class Program
	{
		private static void Main()
		{
			const string serverPath = "http://localhost/";

			var client = new JsonServiceClient(serverPath);

			var whiskys = client.Get(new Whiskies());
		}
	}
}