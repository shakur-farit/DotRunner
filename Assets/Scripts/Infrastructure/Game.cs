using Data;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using UI.Services.Factory;
using UnityEngine;

namespace Infrastructure
{
	public class Game
	{
		private readonly IGameFactory _gameFactory;
		private readonly IUIFactory _uiFactory;
		private readonly ILoadService _loadService;
		private readonly IPersistentProgressService _progressService;

		public Game(IGameFactory gameFactory, IUIFactory uiFactory, ILoadService loadService, IPersistentProgressService progressService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_loadService = loadService;
			_progressService = progressService;
		}

		public void InitObjects()
		{
			InitGameObjects();
			InitUIRoot();
		}

		public void LoadProgress() => 
			_progressService.Progress = _loadService.LoadProgress() ?? NewProgress();

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