using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Dot { get; }
		GameObject Circle { get; }
		void CreateDot();
		void CreateCircle();
	}
}