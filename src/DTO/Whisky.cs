using System;
using System.Diagnostics;
using ServiceStack.ServiceHost;

namespace DTO
{
	[Route("/whiskies", "POST,PUT")]
	[Route("/whiskies/{Id}")]
	[DebuggerDisplay("Name: {Name} ({AlcoholPercentage} %)")]
	public class Whisky
	{
		public Guid Id { get; set; }
		public Guid DistilleryId { get; set; }
		public string Name { get; set; }
		public float AlcoholPercentage { get; set; }
	}
}