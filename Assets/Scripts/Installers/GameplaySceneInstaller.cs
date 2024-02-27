using Data;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Death;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoadService;
using Infrastructure.Services.Scene;
using Infrastructure.Services.TimerService;
using UI.Services.Factory;
using UI.Services.Window;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterInputService();
			RegisterDeathService();
			RegisterAssetsService();
			RegisterRandomService();
			RegisterTimeService();
			RegisterAngleSwitcher();
			RegisterGameFactory();
			RegisterUIFactory();
			RegisterWindowService();
			RegisterSceneService();
			RegisterPersistentProgressService();
			RegisterSaveLoadService();
		}

		private void RegisterSaveLoadService() => 
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();

		private void RegisterPersistentProgressService() => 
			Container.BindInterfacesAndSelfTo<PersistentProgressService>().AsSingle();

		private void RegisterSceneService() => 
			Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();

		private void RegisterAssetsService() => 
			Container.BindInterfacesAndSelfTo<Assets>().AsSingle();

		private void RegisterGameFactory() => 
			Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();

		private void RegisterRandomService() => 
			Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

		private void RegisterInputService() => 
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

		private void RegisterTimeService() => 
			Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();

		private void RegisterAngleSwitcher() => 
			Container.BindInterfacesAndSelfTo<AngleSwitcherService>().AsSingle();

		private void RegisterDeathService() => 
			Container.BindInterfacesAndSelfTo<DeathService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();

		private void RegisterWindowService() => 
			Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
	}
}
