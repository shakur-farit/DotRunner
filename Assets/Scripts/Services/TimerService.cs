using System;
using UnityEngine;
using Zenject;

namespace Services
{
	public class TimerService : ITickable
	{
		public Action TimeIsUp;

		private float _timeDuration;

		public void Tick()
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

		public void ResetTimer(RandomService random) =>
			_timeDuration = random.Next(1f,5f);
	}
}