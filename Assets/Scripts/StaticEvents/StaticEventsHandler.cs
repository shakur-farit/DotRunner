using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static Action StartToPlay;

		public static void OnStartToPlay() => 
			StartToPlay?.Invoke();
	}
}