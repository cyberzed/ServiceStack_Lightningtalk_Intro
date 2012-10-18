using System;
using System.IO;
using DTO;
using Server.Repositories;

namespace Server.DataLoaders
{
	public class WhiskyLoader
	{
		private const string WhiskiesFilePath = "Data\\Whiskies.csv";
		private readonly DistilleryRepository distilleryRepository;
		private readonly WhiskyRepository whiskyRepository;

		public WhiskyLoader(WhiskyRepository whiskyRepository, DistilleryRepository distilleryRepository)
		{
			this.whiskyRepository = whiskyRepository;
			this.distilleryRepository = distilleryRepository;
		}

		public void LoadWhiskies()
		{
			var whiskyFileContent = File.ReadAllLines(WhiskiesFilePath);

			foreach (var whiskyLine in whiskyFileContent)
			{
				var whiskyData = whiskyLine.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

				if (whiskyData.Length == 3)
				{
					var distilleryName = whiskyData[0];
					var whiskyName = whiskyData[1];
					var alcoholPercentage = Convert.ToSingle(whiskyData[2]);

					var distillery = distilleryRepository.Find(distilleryName);

					if (distillery != null)
					{
						var whisky = new Whisky
						             	{
						             		Id = Guid.NewGuid(),
						             		Name = whiskyName,
						             		AlcoholPercentage = alcoholPercentage,
						             		DistilleryId = distillery.Id
						             	};

						whiskyRepository.Store(whisky);
					}
				}
			}
		}
	}
}