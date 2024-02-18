namespace Infrastructure.Services
{
	public interface IAngleSwitcher : IService
	{
		float SwitchAngle(float angle, ITimerService timerService, IRandomService randomService);

		float SwitchAngle(float angle);
	}
}