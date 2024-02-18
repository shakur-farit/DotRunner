using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure
{
	public class Game
	{
		private readonly IGameFactory _gameFactory;

		public Game(IGameFactory gameFactory) => 
			_gameFactory = gameFactory;

		public void InitObjects()
		{
			InitDot();
			InitCircle();
			Debug.Log("Init");
		}

		private void InitDot() => 
			_gameFactory.CreateDot();

		private void InitCircle() =>
			_gameFactory.CreateCircle();
	}
}