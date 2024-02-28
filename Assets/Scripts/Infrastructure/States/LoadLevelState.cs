using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure.States
{
	public class LoadLevelState : IState
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;

		public LoadLevelState(IGameFactory gameFactory, IUIFactory uiFactory)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		public void Enter() => 
			InitObjects();

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