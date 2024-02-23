using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.Services
{
	public class SceneService : ISceneService
	{
		private readonly IGameFactory _gameFactory;

		public SceneService(IGameFactory gameFactory) => 
			_gameFactory = gameFactory;

		public void ReloadScene()
		{
			ClearScene();

			CreateObjects();
		}

		private void CreateObjects()
		{
			CreateDot();
			CreateCircle();
			Debug.Log("Created Object");
		}

		public void ClearScene()
		{
			DestroyDot();
			DestroyCircle();
			Debug.Log("SceneCleared");
		}

		private void CreateCircle() => 
			_gameFactory.CreateCircle();

		private void CreateDot() => 
			_gameFactory.CreateDot();

		private void DestroyDot() => 
			Object.Destroy(_gameFactory.Dot);
		private void DestroyCircle() =>
			Object.Destroy(_gameFactory.Circle);
	}
}