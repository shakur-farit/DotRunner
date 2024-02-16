using Services;
using UnityEngine;

namespace RotatorField
{
	public class Rotator : MonoBehaviour
	{

		private float _zAngle = 1f;
		private TimerService _timerService;
		private RandomService _randomService;
		private AngleSwitcher _angleSwitcher;

		public void Constructor(TimerService timerService, RandomService randomService, AngleSwitcher angleSwitcher)
		{
			_timerService = timerService;
			_randomService = randomService;
			_angleSwitcher = angleSwitcher;
		}

		private void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		private void SwitchAngle() => 
			_zAngle = _angleSwitcher.SwitchAngle(_zAngle, _timerService, _randomService);

		private void Update() => 
			DoRotate();

		private void DoRotate() => 
			transform.Rotate(0f,0f,_zAngle);
	}
}