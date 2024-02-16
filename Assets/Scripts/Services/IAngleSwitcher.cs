namespace Services
{
	public interface IAngleSwitcher
	{
		float SwitchAngle(float zAngle, ITimerService timerService, IRandomService randomService);
	}
}