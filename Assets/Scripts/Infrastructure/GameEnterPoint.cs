using RotatorField;
using UnityEngine;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		[SerializeField] private Rotator _rotator;

		private Game _game;

		private void Awake()
		{
			_game = new Game(_rotator);
			_game.Start();
		}

		private void Update() => 
			_game.Update();
	}
}