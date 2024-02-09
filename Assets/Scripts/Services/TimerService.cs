using System;
using UnityEngine;

namespace Services
{
	public class TimerService
	{
		public Action TimeIsUp;

		private float _timer;

		public TimerService(float timer) => 
			_timer = timer;

		public void UpdateTimer()
		{
			if (_timer < 0)
				return;

			_timer -= Time.deltaTime;

			Debug.Log(_timer);

			if (_timer < 0)
			{
				Debug.Log("Time is up");
				TimeIsUp?.Invoke();
			}
		}
	}
}