using RotatorField;
using Services;

namespace States
{
	public class BootstrapState
	{
		private readonly Rotator _rotator;
		private RandomService _random;
		private AngleSwitcher _angleSwitcher;
		private TimerService _timerService;

		public BootstrapState(Rotator rotator)
		{
			_rotator = rotator;
		}

		public void Enter()
		{
			_random = new RandomService();
			_angleSwitcher = new AngleSwitcher();
			_timerService = new TimerService();
			_rotator.Constructor(_timerService, _random, _angleSwitcher);
		}

		//public void Update() => 
		//	_timerService.UpdateTimer();
	}
}