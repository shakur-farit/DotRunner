namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		protected override void OnAwake() => 
			CloseButton.onClick.AddListener(() => Play());

		private void Play() => 
			throw new System.NotImplementedException();
	}
}