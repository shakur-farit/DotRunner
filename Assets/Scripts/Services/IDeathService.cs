using System;
using UnityEngine;

namespace Services
{
	public interface IDeathService
	{
		event Action IsDead;
		void Destroy(GameObject gameObject);
	}
}