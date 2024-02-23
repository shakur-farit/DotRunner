using Infrastructure.Services;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		private ISceneService _sceneService;

		[Inject]
		private void Constructor(ISceneService sceneService) => 
			_sceneService = sceneService;

		protected override void OnAwake() => 
			CloseButton.onClick.AddListener(() => Restart());

		private void Restart()
		{
			_sceneService.ReloadScene();
			Destroy(gameObject);
		}
	}
}