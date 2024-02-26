using System;
using UnityEngine;

namespace Infrastructure.Services
{
	public class TimerService : ICountdownTimerService, ICountUpTimerService
	{
		public event Action TimeIsUp;
		
		private const float ZeroTime = 0f;

		private float _countdownTimeDuration;

		private bool _isCountUpTimerStopped;
		private bool _isCountdownTimerStopped;
		
		public float CountUpTimeDuration { get; private set; }

		private TimerService(IRandomService randomService) => 
			_countdownTimeDuration = randomService.Next(1f, 5f);

		public void UpdateCountdownTimer()
		{
			if(_isCountdownTimerStopped)
				return;

			if (_countdownTimeDuration < 0)
				return;

			_countdownTimeDuration -= Time.deltaTime;
			Debug.Log($"Countdown: {_countdownTimeDuration}");

			if (_countdownTimeDuration < 0) 
				TimeIsUp?.Invoke();
		}

		public void StartCountdownTimer() =>
			_isCountdownTimerStopped = false;

		public void StopCountdownTimer()
		{
			_isCountdownTimerStopped = true;
			_countdownTimeDuration = ZeroTime;
		}

		public void ResetCountdownTimer(IRandomService random) =>
			_countdownTimeDuration = random.Next(1f, 5f);

		public void UpdateCountUpTimer()
		{
			if(_isCountUpTimerStopped)
				return;

			CountUpTimeDuration += Time.deltaTime;
			Debug.Log($"CountUp: {CountUpTimeDuration}");

		}

		public void StartCountUpTimer()
		{
			CountUpTimeDuration = ZeroTime;
			_isCountUpTimerStopped = false;
		}

		public void StopCountUpTimer() =>
			_isCountUpTimerStopped = true;

	}
}