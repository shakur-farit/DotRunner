namespace Services
{
	public class AngleSwitcher : IAngleSwitcher
	{
		public float SwitchAngle(float zAngle, TimerService timerService, RandomService randomService)
		{
			timerService.ResetTimer(randomService);
			return -zAngle;
		}
	}
}