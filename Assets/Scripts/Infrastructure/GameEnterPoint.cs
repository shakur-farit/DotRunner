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
		private ICountdownTimerService _countdownTimer;
		private ICountUpTimerService _countUpTimer;

		[Inject]
		private void Constructor(IGameFactory gameFactory, IUIFactory uiFactory, ICountdownTimerService countdownTimer,
			ICountUpTimerService countUpTimer)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
		}

		private void Awake()
		{
			_game = new Game(_gameFactory, _uiFactory);
			_game.InitObjects();
		}

		private void Update()
		{
			_countdownTimer.UpdateCountdownTimer();
			_countUpTimer.UpdateCountUpTimer();
		}
	}
}