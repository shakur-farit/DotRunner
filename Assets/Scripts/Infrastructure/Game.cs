using RotatorField;
using States;

namespace Infrastructure
{
	public class Game
	{

		private readonly Rotator _rotator;
		private BootstrapState _bootstrapState;

		public Game(Rotator rotator) => 
			_rotator = rotator;

		public void Start()
		{ 
			_bootstrapState = new BootstrapState(_rotator);
			_bootstrapState.Enter();
		}

		//public void Update() => 
		//	_bootstrapState.Update();
	}
}