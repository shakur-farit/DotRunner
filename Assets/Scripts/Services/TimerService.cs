using System;
using UnityEngine;

namespace Services
{
	public class TimerService
	{
		public Action TimeIsUp;

		private IRandomService _randomService;
		private float _timeDuration;

		public TimerService(IRandomService randomService) => 
			_randomService = randomService;

		public void UpdateTimer()
		{
			if (_timeDuration < 0)
				return;

			_timeDuration -= Time.deltaTime;

			Debug.Log(_timeDuration);

			if (_timeDuration < 0)
			{
				Debug.Log("Time is up");
				TimeIsUp?.Invoke();
			}
		}

		public void ResetTimer(float timeDuration) =>
			_timeDuration = timeDuration;
	}
}