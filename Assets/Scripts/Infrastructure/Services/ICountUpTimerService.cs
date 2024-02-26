namespace Infrastructure.Services
{
	public interface ICountUpTimerService
	{
		void UpdateCountUpTimer();
		void StartCountUpTimer();
		void StopCountUpTimer();
		float CountUpTimeDuration { get; }
	}
}