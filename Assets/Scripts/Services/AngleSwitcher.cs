namespace Services
{
	public class AngleSwitcher : IAngleSwitcher
	{
		public float SwitchAngle(float zAngle, ITimerService timerService, IRandomService randomService)
		{
			timerService.ResetTimer(randomService);
			return -zAngle;
		}
	}
}