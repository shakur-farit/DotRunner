using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Dot { get; }
		GameObject Circle { get; }
		GameObject Hud { get; set; }
		void CreateDot();
		void CreateCircle();
		void CreateHud();
	}
}