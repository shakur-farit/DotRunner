using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action OnStartToPlay;

		public static void StartToPlay() => 
			OnStartToPlay?.Invoke();

		public static Action OnPickupDebuff;

		public static void PickupDebuff() => 
			OnPickupDebuff?.Invoke();
	}
}