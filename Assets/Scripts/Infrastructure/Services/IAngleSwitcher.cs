namespace Infrastructure.Services
{
	public interface IAngleSwitcher : IService
	{
		float SwitchAngle(float angle, ICountdownTimerService countdownTimerService, IRandomService randomService);

		float SwitchAngle(float angle);
	}
}