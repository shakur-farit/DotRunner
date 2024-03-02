using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.TimerService;
using UI.Services.Factory;
using UI.Services.Window;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _states;

		private IState _activeState;

		public GameStateMachine(IStaticDataService staticDataService, IPersistentProgressService progressService,
			ILoadService loadService, IGameFactory gameFactory, IUIFactory uiFactory, IWindowService windowService,
			ICountdownTimerService countdownTimer, ICountUpTimerService countUpTimer)
		{
			_states = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, progressService, loadService),
				[typeof(LoadLevelState)] = new LoadLevelState(this, gameFactory, uiFactory),
				[typeof(GameLoopingState)] = new GameLoopingState(new GameLoopingStateMachine(windowService, staticDataService, 
					countUpTimer, countdownTimer))
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