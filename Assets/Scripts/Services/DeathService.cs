using UnityEngine;

namespace Services
{
	public class DeathService : IDeathService
	{
		public void Destroy(GameObject gameObject) => 
			Object.Destroy(gameObject);
	}
}
