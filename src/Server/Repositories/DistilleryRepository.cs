using System;
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

		public Distillery Find(Guid distilleryId)
		{
			var distillery = (from d in distilleryStore where d.Id == distilleryId select d).SingleOrDefault();

			return distillery;
		}

		public Distillery Find(string distilleryName)
		{
			var distillery = (from d in distilleryStore where d.Name.Contains(distilleryName) select d).Single();

			return distillery;
		}
	}
}