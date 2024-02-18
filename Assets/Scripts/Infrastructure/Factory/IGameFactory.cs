using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject CreateDot();
		GameObject CreateCircle();
	}
}