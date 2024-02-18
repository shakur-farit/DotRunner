using System;

namespace Infrastructure.Services
{
	public interface ITimerService : IService
	{
		event Action TimeIsUp;

		void UpdateTimer();
		void ResetTimer(IRandomService random);
	}
}