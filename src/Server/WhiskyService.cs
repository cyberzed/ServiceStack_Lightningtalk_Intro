using DTO;
using Server.Repositories;
using ServiceStack.ServiceInterface;

namespace Server
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
			if(whiskies.Distillery!=null)
			{
				var distillery = distilleryRepository.Find(whiskies.Distillery.Name);

				var distilleryWhiskies = whiskyRepository.FindByDistillery(distillery);

				return distilleryWhiskies;
			}

			if(!string.IsNullOrWhiteSpace(whiskies.SearchFilter))
			{
				return whiskyRepository.Find(whiskies.SearchFilter);
			}

			return whiskyRepository.GetAll();
		}
	}
}