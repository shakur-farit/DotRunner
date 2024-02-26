namespace Infrastructure.Services
{
	public class AngleSwitcher : IAngleSwitcher
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