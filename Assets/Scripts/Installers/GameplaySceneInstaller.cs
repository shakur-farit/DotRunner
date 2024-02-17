using Services;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterRandomService();
			RegisterInputService();
			RegisterTimeService();
			RegisterAngleSwitcher();
			RegisterDeathService();
		}

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
