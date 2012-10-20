using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace DTO.Requests
{
	[Route("/whiskies", "GET")]
	[Route("/whiskies/{DistilleryId}/{SearchFilter}", "GET")]
	public class Whiskies : IReturn<IList<Whisky>>
	{
		public Guid DistilleryId { get; set; }
		public string SearchFilter { get; set; }
	}
}