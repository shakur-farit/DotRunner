using Infrastructure.Services.StaticData;
using Infrastructure.Services.TimerService;
using UI.Services.Window;

namespace Infrastructure.States
{
	public class MainMenuState : IState
	{
		private const float Zero = 0;

		private readonly IWindowService _windowService;
		private readonly IStaticDataService _staticDataService;
		private readonly ICountUpTimerService _timerUpService;
		private readonly ICountdownTimerService _timerDownService;

		public MainMenuState(IWindowService windowService, IStaticDataService staticDataService,
			ICountUpTimerService timerUpService, ICountdownTimerService timerDownService)
		{
			_windowService = windowService;
			_staticDataService = staticDataService;
			_timerUpService = timerUpService;
			_timerDownService = timerDownService;
		}

		public void Enter()
		{
			_windowService.Open(WindowId.Main);
			_staticDataService.ForRotator.RotateSpeed = Zero;

			StopTimers();
		}

		private void StopTimers()
		{
			_timerUpService.StopCountUpTimer();
			_timerDownService.StopCountdownTimer();
		}

		public void Exit()
		{
		}
	}
}