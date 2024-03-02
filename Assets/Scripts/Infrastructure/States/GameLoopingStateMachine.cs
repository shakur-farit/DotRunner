using System;
using System.Collections.Generic;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TimerService;
using UI.Services.Window;

namespace Infrastructure.States
{
	public class GameLoopingStateMachine
	{
		private readonly Dictionary<Type, IState> _states;

		private IState _activeState;

		public GameLoopingStateMachine(IWindowService windowService, IStaticDataService staticDataService,
			ICountUpTimerService countUpTimer, ICountdownTimerService countdownTimer)
		{
			_states = new Dictionary<Type, IState>()
			{
				[typeof(MainMenuState)] = new MainMenuState(windowService, staticDataService, countUpTimer, countdownTimer),
			};
		}

		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _states[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}