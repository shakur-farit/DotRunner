using Infrastructure.Services;
using Zenject;

namespace Rotators
{
	public class CircleRotator : Rotator
	{
		private ITimerService _timerService;
		private IRandomService _randomService;
		private IDeathService _deathService;

		[Inject]
		private void Constructor(ITimerService timerService, IRandomService randomService, IAngleSwitcher angleSwitcher,
			IDeathService deathService)
		{
			_timerService = timerService;
			_randomService = randomService;
			AngleSwitcher = angleSwitcher;
			_deathService = deathService;
		}

		protected override void Start()
		{
			_timerService.TimeIsUp += SwitchAngle;
			_deathService.IsDead += StopRotate;
		}

		protected override void OnDestroy()
		{
			_timerService.TimeIsUp -= SwitchAngle;
			_deathService.IsDead -= StopRotate;
		}

		protected override void SwitchAngle() =>
			ZAngle = AngleSwitcher.SwitchAngle(ZAngle, _timerService, _randomService);

		private void StopRotate() =>
			enabled = false;
	}
}