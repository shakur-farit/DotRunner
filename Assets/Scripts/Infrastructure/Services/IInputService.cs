using System;

namespace Infrastructure.Services
{
	public interface IInputService : IService

	{
	event Action IsTaped;

	void Tap();
	}
}