using Infrastructure.Services;
using Zenject;

namespace Rotators
{
	public class CircleRotator : Rotator
	{
		private ICountdownTimerService _countdownTimerService;
		private IRandomService _randomService;
		private IDeathService _deathService;

		[Inject]
		private void Constructor(ICountdownTimerService countdownTimerService, IRandomService randomService, IAngleSwitcher angleSwitcher,
			IDeathService deathService)
		{
			_countdownTimerService = countdownTimerService;
			_randomService = randomService;
			AngleSwitcher = angleSwitcher;
			_deathService = deathService;
		}

		protected override void Start()
		{
			_countdownTimerService.TimeIsUp += SwitchAngle;
			_deathService.IsDead += StopRotate;
		}

		protected override void OnDestroy()
		{
			_countdownTimerService.TimeIsUp -= SwitchAngle;
			_deathService.IsDead -= StopRotate;
		}

		protected override void SwitchAngle() =>
			ZAngle = AngleSwitcher.SwitchAngle(ZAngle, _countdownTimerService, _randomService);

		private void StopRotate() =>
			enabled = false;
	}
}