using Services;
using UnityEngine;
using Zenject;

namespace RotatorField
{
	public class Rotator : MonoBehaviour
	{

		private float _zAngle = 1f;
		private ITimerService _timerService;
		private IRandomService _randomService;
		private IAngleSwitcher _angleSwitcher;

		[Inject]
		private void Constructor(ITimerService timerService, IRandomService randomService, IAngleSwitcher angleSwitcher)
		{
			_timerService = timerService;
			_randomService = randomService;
			_angleSwitcher = angleSwitcher;
		}

		private void Start() => 
			_timerService.TimeIsUp += SwitchAngle;

		private void Update() => 
			DoRotate();

		private void DoRotate() => 
			transform.Rotate(0f,0f,_zAngle);

		private void SwitchAngle() =>
			_zAngle = _angleSwitcher.SwitchAngle(_zAngle, _timerService, _randomService);
	}
}