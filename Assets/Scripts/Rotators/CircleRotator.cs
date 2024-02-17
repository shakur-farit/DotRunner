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
			AngleSwitcher = angleSwitcher;
		}

		protected override void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		protected override void SwitchAngle() =>
			ZAngle = AngleSwitcher.SwitchAngle(ZAngle, _timerService, _randomService);
	}
}