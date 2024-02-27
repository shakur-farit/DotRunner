using System;
using UnityEngine;

namespace Infrastructure.Services.Death
{
	public interface IDeathService
	{
		event Action IsDead;
		void Destroy(GameObject gameObject);
	}
}