using System;
using UnityEngine;

namespace Infrastructure.Services
{
	public interface IDeathService
	{
		event Action IsDead;
		void Destroy(GameObject gameObject);
	}
}