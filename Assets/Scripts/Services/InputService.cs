using System;
using UnityEngine;
using Zenject;

namespace Services
{
	public class InputService : IInputService, ITickable
	{
		public event Action IsTaped;

		public void Tick() => 
			Tap();

		public void Tap()
		{
			if (Input.GetKeyDown(KeyCode.W))
			{
				Debug.Log("Tap");
				IsTaped?.Invoke();
			}
		}
	}
}