using System;

namespace Services
{
	public interface IInputService
	{
		event Action IsTaped;

		void Tap();
	}
}