using Infrastructure.Services.Randomizer;
using Infrastructure.Services.TimerService;

namespace Infrastructure.Services.AngleSwitcher
{
	public class AngleSwitcherService : IAngleSwitcherService
	{
		public float SwitchAngle(float angle, ICountdownTimerService countdownTimerService, IRandomService randomService)
		{
			countdownTimerService.ResetCountdownTimer(randomService);
			return -angle;
		}

		public float SwitchAngle(float angle) => 
			-angle;
	}
}