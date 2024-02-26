using System;

namespace Infrastructure.Services
{
	public interface ICountdownTimerService : IService
	{
		event Action TimeIsUp;

		void UpdateCountdownTimer();
		void ResetCountdownTimer(IRandomService random);
		void StartCountdownTimer();
		void StopCountdownTimer();
	}
}