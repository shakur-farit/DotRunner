using Infrastructure.Factory;
using Infrastructure.Services;
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
		private ITimerService _timerService;

		[Inject]
		private void Constructor(IGameFactory gameFactory, IUIFactory uiFactory, ITimerService timerService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_timerService = timerService;
		}

		private void Awake()
		{
			_game = new Game(_gameFactory, _uiFactory);
			_game.InitObjects();
		}

		private void Update() => 
			_timerService.UpdateTimer();
	}
}