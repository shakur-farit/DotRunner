namespace Infrastructure.Services.TimerService
{
	public interface ICountUpTimerService
	{
		void UpdateCountUpTimer();
		void StartCountUpTimer();
		void StopCountUpTimer();
		float CountUpTimeDuration { get; }
	}
}