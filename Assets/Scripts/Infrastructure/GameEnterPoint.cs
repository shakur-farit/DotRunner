using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
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
		private IStaticDataService _staticDataService;

		[Inject]
		private void Constructor(IGameFactory gameFactory, IUIFactory uiFactory, ICountdownTimerService countdownTimer,
			ICountUpTimerService countUpTimer, ILoadService loadService, IPersistentProgressService progressService,
			IStaticDataService staticDataService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
			_loadService = loadService;
			_progressService = progressService;
			_staticDataService = staticDataService;
		}

		private void Awake()
		{
			_game = new Game(_gameFactory, _uiFactory, _loadService, _progressService, _staticDataService);
			_game.LoadStaticData();
			_game.LoadProgress();
			_countdownTimer.SetCountdownTimeDuration();
			_game.InitObjects();
		}

		private void Update()
		{
			_countdownTimer.UpdateCountdownTimer();
			_countUpTimer.UpdateCountUpTimer();
		}
	}
}