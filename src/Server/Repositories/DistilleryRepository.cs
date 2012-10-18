using System.Collections.Generic;
using System.Linq;
using DTO;

namespace Server.Repositories
{
	public class DistilleryRepository
	{
		private readonly List<Distillery> distilleryStore = new List<Distillery>();

		public void Store(Distillery distillery)
		{
			if (!distilleryStore.Contains(distillery))
			{
				distilleryStore.Add(distillery);
			}
		}

		public Distillery Find(string distilleryName)
		{
			return (from d in distilleryStore where d.Name.Equals(distilleryName) select d).SingleOrDefault();
		}
	}
}