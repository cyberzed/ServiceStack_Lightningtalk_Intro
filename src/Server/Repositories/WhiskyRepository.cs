using System.Collections.Generic;
using System.Linq;
using DTO;

namespace Server.Repositories
{
	public class WhiskyRepository
	{
		private readonly List<Whisky> whiskyStore = new List<Whisky>();

		public void Store(Whisky whisky)
		{
			if (!whiskyStore.Contains(whisky))
			{
				whiskyStore.Add(whisky);
			}
		}

		public List<Whisky> FindByDistillery(Distillery distillery)
		{
			var whiskies = (from w in whiskyStore
			                where
			                	w.DistilleryId == distillery.Id
			                select w);

			return whiskies.ToList();
		}

		public List<Whisky> Find(string searchFilter)
		{
			var whiskies = (from w in whiskyStore
			                where
			                	w.Name.Contains(searchFilter)
			                select w);

			return whiskies.ToList();
		}

		public List<Whisky> GetAll()
		{
			return whiskyStore;
		}
	}
}