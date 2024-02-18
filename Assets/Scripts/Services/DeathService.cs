using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
	public class DeathService : IDeathService
	{
		public event Action IsDead;

		public void Destroy(GameObject gameObject)
		{
			IsDead?.Invoke();
			Object.Destroy(gameObject);
		}
	}
}
