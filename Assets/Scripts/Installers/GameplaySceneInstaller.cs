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
		}

		private void RegisterRandomService() => 
			Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();

		private void RegisterInputService() => 
			Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

		private void RegisterTimeService() => 
			Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();

		private void RegisterAngleSwitcher() => 
			Container.BindInterfacesAndSelfTo<AngleSwitcher>().AsSingle();
	}
}
