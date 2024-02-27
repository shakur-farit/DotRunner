using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Scene;
using TMPro;
using Zenject;

namespace UI.Windows
{
	public class GameOverWindow : WindowBase
	{
		public TextMeshProUGUI CurrentTimeText;
		public TextMeshProUGUI BestTimeText;

		private ISceneService _sceneService;
		private IPersistentProgressService _progressService;

		[Inject]
		private void Constructor(ISceneService sceneService,IPersistentProgressService progressService)
		{
			_sceneService = sceneService;
			_progressService = progressService;
		}

		protected override void OnAwake()
		{
			CloseButton.onClick.AddListener(() => Restart());
			CurrentTimeTextUpdate();
			BestTimeTextUpdate();
		}

		private void CurrentTimeTextUpdate() => 
			CurrentTimeText.text = _progressService.Progress.timeData.CurrentTime.ToString();

		private void BestTimeTextUpdate() => 
			BestTimeText.text = _progressService.Progress.timeData.GetBestTime().ToString();

		private void Restart()
		{
			_sceneService.RestartScene();
			Destroy(gameObject);
		}
	}
}