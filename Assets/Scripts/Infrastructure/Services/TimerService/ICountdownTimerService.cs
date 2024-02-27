using System;
using Infrastructure.Services.Randomizer;

namespace Infrastructure.Services.TimerService
{
	public interface ICountdownTimerService
	{
		event Action TimeIsUp;

		void UpdateCountdownTimer();
		void ResetCountdownTimer(IRandomService random);
		void StartCountdownTimer();
		void StopCountdownTimer();
	}
}