using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly GameStateMachine _stateMachine;
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;

		public LoadLevelState(GameStateMachine stateMachine, IGameFactory gameFactory, IUIFactory uiFactory)
		{
			_stateMachine = stateMachine;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		public void Enter()
		{
			InitObjects();
			_stateMachine.Enter<GameLoopingState>();
		}

		public void Exit()
		{
		}

		public void InitObjects()
		{
			InitGameObjects();
			InitUIRoot();
		}

		private void InitGameObjects()
		{
			InitDot();
			InitCircle();
			InitHud();
		}

		private void InitDot() =>
			_gameFactory.CreateDot();

		private void InitCircle() =>
			_gameFactory.CreateCircle();

		private void InitHud() =>
			_gameFactory.CreateHud();

		private void InitUIRoot() =>
			_uiFactory.CreateUIRoot();
	}
}