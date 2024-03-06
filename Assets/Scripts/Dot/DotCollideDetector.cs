using Drops;
using Rotators;
using StaticEvents;
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
			if (other.GetComponent<CircleRotator>())
				CollideWithCircle();

			if (other.GetComponent<Debuff>())
			{
				CollideWithDebuff();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithDebuff()
		{
			StaticEventsHandler.PickupDebuff();
			Debug.Log("PickupDebuff");
		}

		private void CollideWithCircle()
		{
			if(_isCollided)
				return; 
			_isCollided = true;
			_dotDeath.StopTheGame();
			
		}
	}
}