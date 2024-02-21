using Infrastructure.Factory;
using UI.Services.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;
		private IGameFactory _gameFactory;
		private IUIFactory _uiFactory;

		[Inject]
		private void Constructor(IGameFactory gameFactory, IUIFactory uiFactory)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		private void Awake()
		{
			_game = new Game(_gameFactory, _uiFactory);
			_game.InitObjects();
		}
	}
}