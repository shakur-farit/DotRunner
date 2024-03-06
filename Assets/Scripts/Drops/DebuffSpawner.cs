using System.Collections;
using Infrastructure.Factory;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;
using Zenject;

namespace Drops
{
	public class DebuffSpawner : MonoBehaviour

	{
		private float _spawnTime;

		private IGameFactory _gameFactory;
		private IRandomService _randomService;
		private IStaticDataService _staticData;

		[Inject]
		public void Constructor(IGameFactory gameFactory, IRandomService randomService,
			IStaticDataService staticData)
		{
			_gameFactory = gameFactory;
			_randomService = randomService;
			_staticData = staticData;
		}


		private void OnEnable()
		{
			StaticEventsHandler.OnStartedToPlay += SpawnDebuff;
			StaticEventsHandler.OnPlayerDied += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartedToPlay -= SpawnDebuff;
			StaticEventsHandler.OnPlayerDied -= StopSpawning;
		}

		private void SpawnDebuff() => 
			StartCoroutine(SpawnDebuffRoutine());

		private void StopSpawning() => 
			StopAllCoroutines();

		private IEnumerator SpawnDebuffRoutine()
		{
			GetSpawnTime();

			yield return new WaitForSeconds(_spawnTime);
			_gameFactory.CreateDebuff();
			StaticEventsHandler.CallDebuffSpawendEvent();

			StartCoroutine(SpawnDebuffRoutine());
		}

		private void GetSpawnTime()
		{
			float minSpawnTime = _staticData.ForDebuff.MinSpawnCooldown;
			float maxSpawnTime = _staticData.ForDebuff.MaxSpawnCooldown;
			_spawnTime = _randomService.Next(minSpawnTime, maxSpawnTime);
		}
	}
}