using UnityEngine;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;

		private void Awake()
		{
			_game = new Game();
		}
	}
}