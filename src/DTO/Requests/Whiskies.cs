using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace DTO.Requests
{
	[Route("/whiskies", "GET")]
	[Route("/whiskies/{SearchFilter}", "GET")]
	public class Whiskies : IReturn<IList<Whisky>>
	{
		public Distillery Distillery { get; set; }
		public string SearchFilter { get; set; }
	}
}