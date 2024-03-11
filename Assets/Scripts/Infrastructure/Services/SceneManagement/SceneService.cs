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
			DestroyBubble();
			DestroyNeedle();
			DestroyDebuff();
			DestroyBuff();
			DestroyDebuffSpawner();
		}

		private void CreateGameObjects()
		{
			CreateBubble();
			CreateNeedle();
			CreateDebuffSpawner();
		}

		private void CreateBubble() => 
			_gameFactory.CreateBubble();

		private void CreateNeedle() => 
			_gameFactory.CreateNeedle();

		private void CreateDebuffSpawner() => 
			_gameFactory.CreateDebuffSpawner();

		private void DestroyBubble() => 
			Object.Destroy(_gameFactory.Bubble);

		private void DestroyNeedle() =>
			Object.Destroy(_gameFactory.Needle);

		private void DestroyBuff() =>
			Object.Destroy(_gameFactory.Buff);

		private void DestroyDebuff() => 
			Object.Destroy(_gameFactory.Debuff);

		private void DestroyDebuffSpawner() => 
			Object.Destroy(_gameFactory.DebuffSpawner);
	}
}