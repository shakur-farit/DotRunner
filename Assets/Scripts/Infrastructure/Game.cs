using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure
{
	public class Game
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;

		public Game(IGameFactory gameFactory, IUIFactory uiFactory)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
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