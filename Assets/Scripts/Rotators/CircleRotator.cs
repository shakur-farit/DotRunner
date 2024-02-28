using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Death;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.TimerService;
using Zenject;

namespace Rotators
{
	public class CircleRotator : Rotator
	{
		private ICountdownTimerService _countdownTimerService;
		private IRandomService _randomService;
		private IDeathService _deathService;

		[Inject]
		protected void Constructor(ICountdownTimerService countdownTimerService, IRandomService randomService, IAngleSwitcherService angleSwitcherService,
			IDeathService deathService)
		{
			_countdownTimerService = countdownTimerService;
			_randomService = randomService;
			AngleSwitcherService = angleSwitcherService;
			_deathService = deathService;
		}

		protected override void OnStart()
		{
			base.OnStart();

			_countdownTimerService.TimeIsUp += SwitchAngle;
			_deathService.IsDead += StopRotate;
		}

		protected override void OnOnDestroy()
		{
			base.OnOnDestroy();

			_countdownTimerService.TimeIsUp -= SwitchAngle;
			_deathService.IsDead -= StopRotate;
		}

		protected override void SwitchAngle() =>
			RotateAngle = AngleSwitcherService.SwitchAngle(RotateAngle, _countdownTimerService, _randomService);

		private void StopRotate() =>
			enabled = false;
	}
}