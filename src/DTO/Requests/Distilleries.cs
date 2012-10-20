using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace DTO.Requests
{
	[Route("/distilleries", "GET")]
	[Route("/distilleries/{Id}", "GET")]
	[Route("/distilleries/{Region}", "GET")]
	public class Distilleries : IReturn<IList<Distillery>>
	{
		public Guid Id { get; set; }
		public Region Region { get; set; }
	}
}