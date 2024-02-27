using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Death
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
