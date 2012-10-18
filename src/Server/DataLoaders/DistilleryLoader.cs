using System;
using System.IO;
using DTO;
using Server.Repositories;

namespace Server.DataLoaders
{
	public class DistilleryLoader
	{
		private const string DistilleryFilePath = "Data\\Distilleries.csv";
		private readonly DistilleryRepository distilleryRepository;

		public DistilleryLoader(DistilleryRepository distilleryRepository)
		{
			this.distilleryRepository = distilleryRepository;
		}

		public void LoadDistilleries()
		{
			var distilleryFileContent = File.ReadAllLines(DistilleryFilePath);

			foreach (var distilleryLine in distilleryFileContent)
			{
				var distilleryData = distilleryLine.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

				if (distilleryData.Length == 2)
				{
					var distilleryName = distilleryData[0];
					var regionName = distilleryData[1];

					var distillery = new Distillery
					                 	{
					                 		Id = Guid.NewGuid(),
					                 		Name = distilleryName,
					                 		Region = (Region) Enum.Parse(typeof (Region), regionName)
					                 	};

					distilleryRepository.Store(distillery);
				}
			}
		}
	}
}