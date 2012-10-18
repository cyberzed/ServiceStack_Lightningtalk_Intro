using System;
using ServiceStack.ServiceHost;

namespace DTO
{
	[Route("/whiskies", "POST,PUT")]
	[Route("/whiskies/{Id}")]
	public class Whisky
	{
		public Guid Id { get; set; }
		public Guid DistilleryId { get; set; }
		public string Name { get; set; }
		public float AlcoholPercentage { get; set; }
	}
}