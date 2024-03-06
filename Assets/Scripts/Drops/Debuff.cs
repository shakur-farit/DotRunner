using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Drops
{
	public class Debuff : MonoBehaviour
	{
		private readonly WaitForSeconds _timeToDestroy = new(5);

		private void Start() => 
			StartCoroutine(DestroyRoutine());

		private IEnumerator DestroyRoutine()
		{
			yield return _timeToDestroy;
			Destroy(gameObject);
		}
	}
}