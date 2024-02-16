using Services;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ITickable>().To<TimerService>().AsSingle();
		}
	}
}
