using RotatorField;
using Services;

namespace Infrastructure
{
	public class Game
	{
		private TimerService _timerService;
		private readonly Rotator _rotator;
		private RandomService _random;

		public Game(Rotator rotator) => 
			_rotator = rotator;

		public void Start()
		{
			_random = new RandomService();
			_timerService = new TimerService(_random.Next(1f ,5f));
			_rotator.Constructor(_timerService, _random);
		}

		public void Update() => 
			_timerService.UpdateTimer();
	}
}