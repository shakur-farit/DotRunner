using Infrastructure.Services;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Dot
{
	public class DotCollideDetector : MonoBehaviour
	{
		private IDeathService _deathService;
		private IWindowService _windowService;

		private bool _isCollided = false;

		[Inject]
		public void Constructor(IDeathService deathService, IWindowService windowService)
		{
			_deathService = deathService;
			_windowService = windowService;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(_isCollided)
				return;

			_isCollided = true;
			_windowService.Open(WindowId.GameOver);
			_deathService.Destroy(gameObject);
		}
	}
}