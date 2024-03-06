using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action OnStartedToPlay;
		public static Action OnPickupedDebuff;
		public static Action OnDebuffSpawned;
		public static Action OnPlayerDied;


		public static void CallStartedToPlayEvent() => 
			OnStartedToPlay?.Invoke();

		public static void CallPickupedDebuffEvent() => 
			OnPickupedDebuff?.Invoke();

		public static void CallPlayerDiedEvent() => 
			OnPlayerDied?.Invoke();

		public static void CallDebuffSpawendEvent() => 
			OnDebuffSpawned?.Invoke();
	}
}