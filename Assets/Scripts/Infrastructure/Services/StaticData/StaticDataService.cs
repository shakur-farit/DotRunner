using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService : IStaticDataService
	{
		private const string TimerStaticDataPath = "StaticData/Timer Static Data";
		private const string RotatorStaticDataPath = "StaticData/Rotator Static Data";

		public RotatorStaticData ForRotator { get; private set; }

		public TimerStaticData ForTimer { get; private set; }

		public void Load()
		{
			ForRotator = Resources.Load<RotatorStaticData>(RotatorStaticDataPath);
			ForTimer = Resources.Load<TimerStaticData>(TimerStaticDataPath);
			Debug.Log(ForTimer);
		}
	}
}