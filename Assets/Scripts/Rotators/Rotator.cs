using System;
using System.Collections;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		protected float RotateAngle;
		protected float RotateSpeed;

		protected IAngleSwitcherService AngleSwitcherService;

		private IStaticDataService _staticDataService;

		[Inject]
		private void Constructor(IStaticDataService staticData) => 
			_staticDataService = staticData;

		private void Start() => 
			OnStart();

		private void OnDestroy() => 
			OnOnDestroy();

		protected virtual void OnStart()
		{
			RotateAngle = _staticDataService.ForRotator.RotateAngle;
			RotateSpeed = _staticDataService.ForRotator.RotateSpeed;
			IncreaseRotateSpeed();
		}

		protected virtual void OnOnDestroy() => 
			StopAllCoroutines();

		protected virtual void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, RotateAngle * RotateSpeed);

		protected abstract void SwitchAngle();

		private void IncreaseRotateSpeed() => 
			StartCoroutine(IncreaseRotateSpeedRoutine());

		private IEnumerator IncreaseRotateSpeedRoutine()
		{
			yield return new WaitForSeconds(_staticDataService.ForRotator.SpeedChangeCooldown);
			RotateSpeed += _staticDataService.ForRotator.SpeedChangeValue;
			IncreaseRotateSpeed();
		}
	}
}