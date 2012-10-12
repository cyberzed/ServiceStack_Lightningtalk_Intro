using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace DTO
{
	public class Whiskies : IReturn<IList<Whisky>>
	{
		public Distillery Distillery { get; set; }
		public string SearchFilter { get; set; }
	}
}