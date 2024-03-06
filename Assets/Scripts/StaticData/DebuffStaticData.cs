using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Debuff Static Data", menuName = "Static Data/Debuff")]
	public class DebuffStaticData : ScriptableObject
	{
		[Range(5, 15)] public int MinSpawnCooldown;
		[Range(5, 15)] public int MaxSpawnCooldown;

		public int TimeToDestroy;

		public float RotateSpeedIncreasingValue;
	}
}