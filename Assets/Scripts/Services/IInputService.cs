using System;

namespace Services
{
	public interface IInputService : IService

	{
	event Action IsTaped;

	void Tap();
	}
}