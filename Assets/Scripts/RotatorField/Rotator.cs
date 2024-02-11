using Services;
using UnityEngine;

namespace RotatorField
{
	public class Rotator : MonoBehaviour
	{

		private float _zAngle = 1f;
		private TimerService _timerService;
		private RandomService _randomService;

		public void Constructor(TimerService timerService, RandomService randomService)
		{
			_timerService = timerService;
			_randomService = randomService;
		}

		private void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		private void SwitchAngle()
		{
			_zAngle = -_zAngle;
			_timerService.ResetTimer(_randomService.Next(1f, 5f));
		}

		private void Update() => 
			DoRotate();

		private void DoRotate() => 
			transform.Rotate(0f,0f,_zAngle);
	}
}