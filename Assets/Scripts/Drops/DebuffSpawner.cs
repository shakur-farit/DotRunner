using System.Collections;
using Infrastructure.Factory;
using Infrastructure.Services.Death;
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
		private IDeathService _deathService;
		private IRandomService _randomService;
		private IStaticDataService _staticData;

		[Inject]
		public void Constructor(IGameFactory gameFactory, IDeathService deathService, IRandomService randomService,
			IStaticDataService staticData)
		{
			_gameFactory = gameFactory;
			_deathService = deathService;
			_randomService = randomService;
			_staticData = staticData;
		}


		private void OnEnable()
		{
			StaticEventsHandler.OnStartToPlay += SpawnDebuff;
			_deathService.IsDead += StopSpawning;
		}

		private void OnDisable()
		{
			StaticEventsHandler.OnStartToPlay -= SpawnDebuff;
			_deathService.IsDead -= StopSpawning;
		}

		private void Start() => 
			GetSpawnTime();

		private void SpawnDebuff() =>
			StartCoroutine(SpawnDebuffRoutine());

		private void StopSpawning()
		{
			Debug.Log("StopRoutine");
			StopAllCoroutines();
		}

		private IEnumerator SpawnDebuffRoutine()
		{
			yield return new WaitForSeconds(_spawnTime);
			_gameFactory.CreateDebuff();
			Debug.Log("Spawn");
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