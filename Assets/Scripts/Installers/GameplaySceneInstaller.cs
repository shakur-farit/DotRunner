using Services;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<RandomService>().AsSingle();
			Container.BindInterfacesAndSelfTo<TimerService>().AsSingle();
			Container.BindInterfacesAndSelfTo<AngleSwitcher>().AsSingle();
		}
	}
}
