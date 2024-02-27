using UnityEngine;

namespace Dot
{
	[RequireComponent(typeof(DotDeath))]
	public class DotCollideDetector : MonoBehaviour
	{
		private DotDeath _dotDeath;
		private bool _isCollided;

		private void Start() => 
			_dotDeath = GetComponent<DotDeath>();

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(_isCollided)
				return;

			_isCollided = true;

			_dotDeath.StopTheGame();
		}
	}
}