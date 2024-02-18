using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services
{
	public class TimerService : ITimerService, ITickable
	{
		public event Action TimeIsUp;

		private float _timeDuration;

		private TimerService(IRandomService randomService) => 
			_timeDuration = randomService.Next(1f, 5f);

		public void Tick() => 
			UpdateTimer();

		public void UpdateTimer()
		{
			if (_timeDuration < 0)
				return;

			_timeDuration -= Time.deltaTime;

			if (_timeDuration < 0) 
				TimeIsUp?.Invoke();
		}

		public void ResetTimer(IRandomService random) =>
			_timeDuration = random.Next(1f, 5f);
	}
}