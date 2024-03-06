using System.Collections;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public class Debuff : MonoBehaviour
	{
		private readonly WaitForSeconds _timeToDestroy = new(5);

		private void Start()
		{
			StaticEventsHandler.OnPlayerDied += DestroyDebuff;

			StartCoroutine(DestroyRoutine());
		}

		private void OnDestroy()
		{
			StaticEventsHandler.OnPlayerDied -= DestroyDebuff;

			StopAllCoroutines();
		}

		private void DestroyDebuff() => 
			Destroy(gameObject);

		private IEnumerator DestroyRoutine()
		{
			yield return _timeToDestroy;
			Destroy(gameObject);
		}
	}
}