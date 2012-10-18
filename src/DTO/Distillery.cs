using System;
using ServiceStack.ServiceHost;

namespace DTO
{
	[Route("/region", "GET")]
	[Route("/region/{Region}", "GET")]
	public class Distillery
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Region Region { get; set; }
	}
}