using Services;

namespace States
{
	public class BootstrapState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private TimerService _timerService;
		private RandomService _randomService;

		public BootstrapState(GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}

		public void Enter()
		{
		}

		public void Exit()
		{
		}

		private void RegisterServices()
		{
			_timerService = new TimerService(_randomService);
		}
	}
}