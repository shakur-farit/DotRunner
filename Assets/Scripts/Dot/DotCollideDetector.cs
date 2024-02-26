using Infrastructure.Services;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Dot
{
	public class DotCollideDetector : MonoBehaviour
	{
		private IDeathService _deathService;
		private IWindowService _windowService;

		private bool _isCollided;
		private ICountdownTimerService _countdownTimer;
		private ICountUpTimerService _countUpTimer;

		[Inject]
		public void Constructor(IDeathService deathService, IWindowService windowService,
			ICountdownTimerService countdownTimer, ICountUpTimerService countUpTimer)
		{
			_deathService = deathService;
			_windowService = windowService;
			_countdownTimer = countdownTimer;
			_countUpTimer = countUpTimer;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(_isCollided)
				return;

			_isCollided = true;

			StopTheGame();
		}

		private void StopTheGame()
		{
			OpenGameOverWindow();
			StopTimers();
			DestroyDot();
		}

		private void StopTimers()
		{
			_countdownTimer.StopCountdownTimer();
			_countUpTimer.StopCountUpTimer();
		}

		private void OpenGameOverWindow() => 
			_windowService.Open(WindowId.GameOver);

		private void DestroyDot() => 
			_deathService.Destroy(gameObject);
	}
}