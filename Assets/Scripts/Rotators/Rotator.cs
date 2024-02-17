using Services;
using UnityEngine;

namespace Rotators
{
	public abstract class Rotator : MonoBehaviour
	{
		protected float _zAngle = 1f;

		protected IAngleSwitcher _angleSwitcher;

		protected abstract void Start();


		private void Update() =>
			DoRotate();

		protected void DoRotate() =>
			transform.Rotate(0f, 0f, _zAngle);

		protected abstract void SwitchAngle();
	}
}