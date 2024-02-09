using RotatorField;
using Services;

namespace Infrastructure
{
	public class Game
	{
		private TimerService _timerService;
		private readonly Rotator _rotator;

		public Game(Rotator rotator) => 
			_rotator = rotator;

		public void Start()
		{ 
			_timerService = new TimerService(5);
			_rotator.Constructor(_timerService);
		}

		public void Update() => 
			_timerService.UpdateTimer();
	}
}