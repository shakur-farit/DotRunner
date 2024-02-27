using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.TimerService;
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
		private ILoadService _loadService;
		private IPersistentProgressService _progressService;

		[Inject]
		private void Constructor(IGameFactory gameFactory, IUIFactory uiFactory, ICountdownTimerService countdownTimer,
			ICountUpTimerService countUpTimer, ILoadService loadService, IPersistentProgressService progressService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
			_loadService = loadService;
			_progressService = progressService;
		}

		private void Awake()
		{
			_game = new Game(_gameFactory, _uiFactory, _loadService, _progressService);
			_game.LoadProgress();
			_game.InitObjects();
		}

		private void Update()
		{
			_countdownTimer.UpdateCountdownTimer();
			_countUpTimer.UpdateCountUpTimer();
		}
	}
}