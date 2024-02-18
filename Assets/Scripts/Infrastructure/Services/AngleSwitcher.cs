namespace Infrastructure.Services
{
	public class AngleSwitcher : IAngleSwitcher
	{
		public float SwitchAngle(float angle, ITimerService timerService, IRandomService randomService)
		{
			timerService.ResetTimer(randomService);
			return -angle;
		}

		public float SwitchAngle(float angle) => 
			-angle;
	}
}