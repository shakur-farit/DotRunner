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
		private bool _isCollidedWithBuff;
		private bool _isCollidedWithDebuff;

		private void Start()
		{
			_dotDeath = GetComponent<DotDeath>();

			StaticEventsHandler.OnBuffSpawned += InformAboutNewBuff;
			StaticEventsHandler.OnDebuffSpawned += InformAboutNewDebuff;
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnBuffSpawned -= InformAboutNewBuff;
			StaticEventsHandler.OnDebuffSpawned -= InformAboutNewDebuff;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.GetComponent<CircleRotator>())
				CollideWithCircle();

			if (other.GetComponent<Debuff>())
			{
				CollideWithDebuff();
				Destroy(other.gameObject);
			}

			if (other.GetComponent<Buff>())
			{
				CollideWithBuff();
				Destroy(other.gameObject);
			}
		}

		private void CollideWithBuff()
		{
			if (_isCollidedWithBuff)
				return;

			Debug.Log("Buf");
			_isCollidedWithBuff = true;
			StaticEventsHandler.CallPickedUpBuffEvent();
		}

		private void CollideWithDebuff()
		{
			if(_isCollidedWithDebuff)
				return;

			Debug.Log("Debuf");
			_isCollidedWithDebuff = true;
			StaticEventsHandler.CallPickedUpDebuffEvent();
		}

		private void CollideWithCircle()
		{
			if(_isCollidedWithCircle)
				return; 

			_isCollidedWithCircle = true;
			_dotDeath.StopTheGame();
			
		}

		private void InformAboutNewBuff() =>
			_isCollidedWithBuff = false;

		private void InformAboutNewDebuff() => 
			_isCollidedWithDebuff = false;
	}
}