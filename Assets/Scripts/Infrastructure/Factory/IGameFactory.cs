using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Dot { get; }
		GameObject Circle { get; }
		GameObject Debuff { get; }
		GameObject DebuffSpawner { get; }

		void CreateDot();
		void CreateCircle();
		void CreateHud();
		void CreateDebuff();
		void CreateDebuffSpawner();
	}
}