using Services;
using UnityEngine;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		protected float ZAngle = 0.5f;

		protected IAngleSwitcher AngleSwitcher;

		protected abstract void Start();

		protected abstract void OnDestroy();

		protected virtual void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, ZAngle);

		protected abstract void SwitchAngle();
	}
}