using Data;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;

namespace Infrastructure
{
	public class Game
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;
		private readonly ILoadService _loadService;
		private readonly IPersistentProgressService _progressService;
		private readonly IStaticDataService _staticDataService;

		public Game(IGameFactory gameFactory, IUIFactory uiFactory, ILoadService loadService,
			IPersistentProgressService progressService, IStaticDataService staticDataService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_loadService = loadService;
			_progressService = progressService;
			_staticDataService = staticDataService;
		}

		public void LoadStaticData() => 
			_staticDataService.Load();

		public void LoadProgress() => 
			_progressService.Progress = _loadService.LoadProgress() ?? NewProgress();

		public void InitObjects()
		{
			InitGameObjects();
			InitUIRoot();
		}

		private Progress NewProgress() => 
			new();

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