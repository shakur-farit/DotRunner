using Services;
using Zenject;

namespace Rotators
{
	public class CircleRotator : Rotator
	{
		private ITimerService _timerService;
		private IRandomService _randomService;

		[Inject]
		private void Constructor(ITimerService timerService, IRandomService randomService, IAngleSwitcher angleSwitcher)
		{
			_timerService = timerService;
			_randomService = randomService;
			_angleSwitcher = angleSwitcher;
		}

		protected override void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		protected override void SwitchAngle() =>
			_zAngle = _angleSwitcher.SwitchAngle(_zAngle, _timerService, _randomService);
	}
}