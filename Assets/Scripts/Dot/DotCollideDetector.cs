using Services;
using UnityEngine;
using Zenject;

namespace Dot
{
	public class DotCollideDetector : MonoBehaviour
	{
		private IDeathService _deathService;

		[Inject]
		public void Constructor(IDeathService deathService) => 
			_deathService = deathService;

		private void OnTriggerEnter2D(Collider2D other) => 
			_deathService.Destroy(gameObject);
	}
}