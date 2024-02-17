namespace Services
{
	public interface IAngleSwitcher
	{
		float SwitchAngle(float angle, ITimerService timerService, IRandomService randomService);

		float SwitchAngle(float angle);
	}
}