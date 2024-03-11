using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.TimerService;
using StaticEvents;
using Zenject;

namespace Rotators
{
	public class NeedleRotator : Rotator
	{
		private ICountdownTimerService _countdownTimerService;
		private IRandomService _randomService;

		[Inject]
		protected void Constructor(ICountdownTimerService countdownTimerService, IRandomService randomService, 
			IAngleSwitcherService angleSwitcherService)
		{
			_countdownTimerService = countdownTimerService;
			_randomService = randomService;
			AngleSwitcherService = angleSwitcherService;
		}

		protected override void OnStart()
		{
			_countdownTimerService.TimeIsUp += SwitchAngle;
			StaticEventsHandler.OnPlayerDied += StopRotate;
		}

		public override void OnOnDestroy()
		{
			base.OnOnDestroy();

			_countdownTimerService.TimeIsUp -= SwitchAngle;
			StaticEventsHandler.OnPlayerDied -= StopRotate;
		}

		protected override void SwitchAngle() =>
			RotateAngle = AngleSwitcherService.SwitchAngle(RotateAngle, _countdownTimerService, _randomService);
	}
}