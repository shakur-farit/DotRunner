using Infrastructure.Factory;
using Infrastructure.Services.TimerService;
using UnityEngine;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable, IQuitable
	{
		private readonly IGameFactory _gameFactory;
		private readonly ICountdownTimerService _countdownTimer;
		private readonly ICountUpTimerService _countUpTimer;

		public SceneService(IGameFactory gameFactory, ICountdownTimerService countdownTimer, ICountUpTimerService countUpTimer)
		{
			_gameFactory = gameFactory;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
		}

		public void RestartScene()
		{
			ClearScene();
			CreateGameObjects();
			RestartTimers();
		}

		public void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying =false;
#else
			Application.Quit();
#endif
		}

		private void RestartTimers()
		{
			_countdownTimer.StartCountdownTimer();
			_countUpTimer.StartCountUpTimer();
		}

		private void ClearScene()
		{
			DestroyDot();
			DestroyCircle();
			DestroyDebuff();
			DestroyDebuffSpawner();
		}

		private void CreateGameObjects()
		{
			CreateDot();
			CreateCircle();
			CreateDebufSpawner();
		}

		private void CreateCircle() => 
			_gameFactory.CreateCircle();

		private void CreateDot() => 
			_gameFactory.CreateDot();

		private void CreateDebufSpawner() => 
			_gameFactory.CreateDebuffSpawner();

		private void DestroyDot() => 
			Object.Destroy(_gameFactory.Dot);

		private void DestroyCircle() =>
			Object.Destroy(_gameFactory.Circle);

		private void DestroyDebuff() => 
			Object.Destroy(_gameFactory.Debuff);

		private void DestroyDebuffSpawner() => 
			Object.Destroy(_gameFactory.DebuffSpawner);
	}
}