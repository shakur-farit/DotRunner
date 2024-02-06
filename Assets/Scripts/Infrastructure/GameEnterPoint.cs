using UnityEngine;

namespace Infrastructure
{
	public class GameEnterPoint : MonoBehaviour
	{
		private Game _game;

		private void Start()
		{
			_game = new Game();
		}
	}
}