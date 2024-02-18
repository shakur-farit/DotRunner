using Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;
		private IGameFactory _gameFactory;

		[Inject]
		private void Constructor(IGameFactory gameFactory) => 
			_gameFactory = gameFactory;

		private void Awake()
		{
			_game = new Game(_gameFactory);
			_game.InitObjects();
		}
	}
}