namespace Services
{
	public interface IAngleSwitcher
	{
		float SwitchAngle(float zAngle, TimerService timerService, RandomService randomService);
	}
}