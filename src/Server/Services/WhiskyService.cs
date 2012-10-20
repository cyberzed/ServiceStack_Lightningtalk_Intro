using System;
using DTO.Requests;
using Server.Repositories;
using ServiceStack.ServiceInterface;

namespace Server.Services
{
	public class WhiskyService : Service
	{
		private readonly DistilleryRepository distilleryRepository;
		private readonly WhiskyRepository whiskyRepository;

		public WhiskyService(DistilleryRepository distilleryRepository, WhiskyRepository whiskyRepository)
		{
			this.distilleryRepository = distilleryRepository;
			this.whiskyRepository = whiskyRepository;
		}

		public object Get(Whiskies whiskies)
		{
			if (whiskies.DistilleryId != Guid.Empty)
			{
				var distillery = distilleryRepository.Find(whiskies.DistilleryId);

				var distilleryWhiskies = whiskyRepository.FindByDistillery(distillery);

				return distilleryWhiskies;
			}

			if (!string.IsNullOrWhiteSpace(whiskies.SearchFilter))
			{
				return whiskyRepository.Find(whiskies.SearchFilter);
			}

			return whiskyRepository.GetAll();
		}
	}
}