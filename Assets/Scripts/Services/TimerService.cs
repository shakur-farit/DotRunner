using System;
using UnityEngine;

namespace Services
{
	public class TimerService
	{
		public Action TimeIsUp;

		private float _timeDuration;

		public TimerService(float timeDuration)
		{
			_timeDuration = timeDuration;
		}

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