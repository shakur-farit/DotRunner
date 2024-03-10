using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject Dot { get; }
		GameObject Circle { get; }
		GameObject Debuff { get; }
		GameObject DebuffSpawner { get; }
		GameObject Buff { get; }

		void CreateDot();
		void CreateCircle();
		void CreateHud();
		void CreateDebuff(Vector2 position, Transform parentTransform);
		void CreateBuff(Vector2 position, Transform transform);
		void CreateDebuffSpawner();
	}
}