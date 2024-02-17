using System;
using UnityEngine;

namespace Services
{
	public class InputService : IInputService
	{
		public event Action IsTaped;

		public void Tap()
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

				if(touch.phase == TouchPhase.Began)
					IsTaped?.Invoke();
			}
		}
	}
}