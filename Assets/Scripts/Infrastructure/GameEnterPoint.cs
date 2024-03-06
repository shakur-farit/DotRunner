using Drops;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TimerService;
using Infrastructure.States;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;

		private IStaticDataService _staticDataService;
		private IPersistentProgressService _progressService;
		private ILoadService _loadService;

		private IGameFactory _gameFactory;
		private IUIFactory _uiFactory;
		private IWindowService _windowService;

		private ICountdownTimerService _countdownTimer;
		private ICountUpTimerService _countUpTimer;

		[Inject]
		private void Constructor(IStaticDataService staticDataService, IPersistentProgressService progressService,
			ILoadService loadService, IGameFactory gameFactory, IUIFactory uiFactory, IWindowService windowService,
			ICountdownTimerService countdownTimer, ICountUpTimerService countUpTimer)
		{
			_staticDataService = staticDataService;
			_progressService = progressService;
			_loadService = loadService;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_windowService = windowService;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _progressService, _loadService, 
				_gameFactory, _uiFactory, _windowService);
			_game.StateMachine.Enter<LoadStaticDataState>();

			StopTiming();
		}

		private void Start() => 
			StaticEventsHandler.OnStartedToPlay += StartTiming;

		private void OnDestroy() => 
			StaticEventsHandler.OnStartedToPlay -= StartTiming;

		private void Update()
		{
			_countdownTimer.UpdateCountdownTimer();
			_countUpTimer.UpdateCountUpTimer();
		}

		private void StartTiming()
		{
			_countUpTimer.StartCountUpTimer();
			_countdownTimer.StartCountdownTimer();

			_countdownTimer.SetCountdownTimeDuration();
		}

		private void StopTiming()
		{
			_countUpTimer.StopCountUpTimer();
			_countdownTimer.StopCountdownTimer();
		}
	}
}