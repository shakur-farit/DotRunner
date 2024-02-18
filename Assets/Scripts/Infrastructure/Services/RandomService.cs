using UnityEngine;

namespace Infrastructure.Services
{
	public class RandomService : IRandomService
	{
		public float Next(float min, float max) =>
			Random.Range(min, max);
	}
}