using Infrastructure.Services.Randomizer;
using Infrastructure.Services.TimerService;

namespace Infrastructure.Services.AngleSwitcher
{
	public interface IAngleSwitcherService
	{
		float SwitchAngle(float angle, ICountdownTimerService countdownTimerService, IRandomService randomService);

		float SwitchAngle(float angle);
	}
}