using System;

namespace Infrastructure.States
{
	public class GameLoopingState : IState
	{
		private readonly GameLoopingStateMachine _gameLoopingStateMachine;

		public GameLoopingState(GameLoopingStateMachine gameLoopingStateMachine) => 
			_gameLoopingStateMachine = gameLoopingStateMachine;

		public void Enter()
		{
			_gameLoopingStateMachine.Enter<MainMenuState>();
		}

		public void Exit()
		{
		}
	}
}