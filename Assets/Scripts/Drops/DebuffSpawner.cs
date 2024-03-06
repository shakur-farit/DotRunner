using System.Collections;
using Infrastructure.Factory;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public class DebuffSpawner : MonoBehaviour

	{
		private readonly WaitForSeconds _spawnTime = new(5);

		private IGameFactory _gameFactory;

		[Inject]
		public void Constructor(IGameFactory gameFactory) =>
			_gameFactory = gameFactory;


		private void Start() =>
			StaticEventsHandler.OnStartToPlay += SpawnDebuff;

		private void OnDestroy() =>
			StaticEventsHandler.OnStartToPlay -= SpawnDebuff;

		private void SpawnDebuff() =>
			StartCoroutine(SpawnDebuffRoutine());


		private IEnumerator SpawnDebuffRoutine()
		{
			Debug.Log("Here");
			yield return _spawnTime;
			_gameFactory.CreateDebuff();
		}
	}
}