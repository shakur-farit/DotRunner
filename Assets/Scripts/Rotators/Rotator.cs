using System.Collections;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		private const float Zero = 0;
		protected float RotateAngle;
		protected float RotateSpeed;

		protected IAngleSwitcherService AngleSwitcherService;

		private IStaticDataService _staticDataService;

		[Inject]
		private void Constructor(IStaticDataService staticData) => 
			_staticDataService = staticData;

		private void Start()
		{
			OnStart();
		}

		private void OnDestroy() => 
			OnOnDestroy();

		public void StopRotate() =>
			enabled = false;

		protected virtual void OnStart()
		{
			RotateAngle = Zero;
			RotateSpeed = Zero;

			StaticEventsHandler.StartToPlay += StartRotate;
		}

		protected virtual void OnOnDestroy()
		{
			StaticEventsHandler.StartToPlay -= StartRotate;

			StopAllCoroutines();
		}

		protected virtual void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, RotateAngle * RotateSpeed);

		protected abstract void SwitchAngle();

		private void StartRotate()
		{
			SetupAngleAndSpeed();
			StartToIncreaseRotateSpeed();
		}

		private void SetupAngleAndSpeed()
		{
			RotateAngle = _staticDataService.ForRotator.RotateAngle;
			RotateSpeed = _staticDataService.ForRotator.RotateSpeed;
		}

		private void StartToIncreaseRotateSpeed() => 
			StartCoroutine(IncreaseRotateSpeedRoutine());

		private IEnumerator IncreaseRotateSpeedRoutine()
		{
			yield return new WaitForSeconds(_staticDataService.ForRotator.SpeedChangeCooldown);
			RotateSpeed += _staticDataService.ForRotator.SpeedChangeValue;
			StartToIncreaseRotateSpeed();
		}
	}
}