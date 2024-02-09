using Services;
using UnityEngine;

namespace RotatorField
{
	public class Rotator : MonoBehaviour
	{

		private float _zAngle = 1f;
		private TimerService _timerService;

		public void Constructor(TimerService timerService) => 
			_timerService = timerService;

		private void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		private void SwitchAngle() => 
			_zAngle = -_zAngle;

		private void Update()
		{
			DoRotate();
		}

		private void DoRotate()
		{
			transform.Rotate(0f,0f,_zAngle);
		}


	}
}