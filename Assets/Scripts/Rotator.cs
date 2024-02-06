using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{

	private float _zAngle = 1f;
	private RotateAngleSwitcher _rotateSwitcher;

	private void Start()
	{
		_rotateSwitcher = new RotateAngleSwitcher();
	}

	private void Update()
	{
		DoRotate();
	}

	private void DoRotate()
	{
		transform.Rotate(0f,0f,_zAngle);
	}


}

public class RotateAngleSwitcher
{
	private float _timer = 10;

	private float SwitchRotateVector(float zAngle)
	{
		while (_timer > 0)
		{
			_timer -= Time.deltaTime;
		}

		return zAngle *= -1;
	}
}

