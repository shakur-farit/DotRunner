using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
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
		}

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
			Container.BindInterfacesAndSelfTo<AngleSwitcher>().AsSingle();

		private void RegisterDeathService() => 
			Container.BindInterfacesAndSelfTo<DeathService>().AsSingle();

		private void RegisterUIFactory() => 
			Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle();

		private void RegisterWindowService() => 
			Container.BindInterfacesAndSelfTo<WindowService>().AsSingle();
	}
}
