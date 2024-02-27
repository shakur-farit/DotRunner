using Infrastructure.Services;
using Infrastructure.Services.AngleSwitcher;
using UnityEngine;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		protected float ZAngle = 0.3f;

		protected IAngleSwitcherService AngleSwitcherService;

		protected abstract void Start();

		protected abstract void OnDestroy();

		protected virtual void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, ZAngle);

		protected abstract void SwitchAngle();
	}
}