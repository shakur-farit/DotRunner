using Infrastructure.Services.Death;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.TimerService;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Dot
{
	public class DotDeath : MonoBehaviour
	{
		private IDeathService _deathService;
		private IWindowService _windowService;
		private ICountdownTimerService _countdownTimer;
		private ICountUpTimerService _countUpTimer;
		private IPersistentProgressService _progressService;
		private ISaveService _saveService;

		[Inject]
		public void Construct(IDeathService deathService, IWindowService windowService,
			ICountdownTimerService countdownTimer, ICountUpTimerService countUpTimer,
			IPersistentProgressService progressService, ISaveService saveService)
		{
			_deathService = deathService;
			_windowService = windowService;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
			_progressService = progressService;
			_saveService = saveService;
		}

		public void StopTheGame()
		{
			StopTimers();
			UpdateCurrentTime();
			SaveBestTime();
			OpenGameOverWindow();
			DestroyDot();
		}

		private void StopTimers()
		{
			_countdownTimer.StopCountdownTimer();
			_countUpTimer.StopCountUpTimer();
		}

		private void UpdateCurrentTime() => 
			_progressService.Progress.timeData.CurrentTime = (int)_countUpTimer.CountUpTimeDuration;

		private void SaveBestTime()
		{
			int currentTime = _progressService.Progress.timeData.CurrentTime;
			int bestTime = _progressService.Progress.timeData.BestTime;

			if (currentTime > bestTime)
				_progressService.Progress.timeData.BestTime = currentTime;

			_saveService.SaveProgress();
		}

		private void OpenGameOverWindow() =>
			_windowService.Open(WindowId.GameOver);

		private void DestroyDot() =>
			_deathService.Destroy(gameObject);
	}
}