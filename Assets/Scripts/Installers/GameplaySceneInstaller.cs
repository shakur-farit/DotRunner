using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
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
		}

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
	}
}
