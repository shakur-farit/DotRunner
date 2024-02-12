using System;

namespace Services
{
	public interface ITimerService : IService
	{
		event Action TimeIsUp;

		void UpdateTimer();
		void ResetTimer(float timeDuration);
	}
}