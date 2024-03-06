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
		private bool _isCollidedWithCircle;
		private bool _isCollidedWithDebuff;

		private void Start()
		{
			_dotDeath = GetComponent<DotDeath>();

			StaticEventsHandler.OnDebuffSpawned += InformAboutNewDebuff;
		}

		private void OnDestroy() => 
			StaticEventsHandler.OnDebuffSpawned -= InformAboutNewDebuff;

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
			if(_isCollidedWithDebuff)
				return;

			Debug.Log("Debuf");
			_isCollidedWithDebuff = true;
			StaticEventsHandler.CallPickupedDebuffEvent();
		}

		private void CollideWithCircle()
		{
			if(_isCollidedWithCircle)
				return; 

			_isCollidedWithCircle = true;
			_dotDeath.StopTheGame();
			
		}

		private void InformAboutNewDebuff() => 
			_isCollidedWithDebuff = false;
	}
}