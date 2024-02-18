using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssets _assets;

		public GameFactory(IAssets assets) => 
			_assets = assets;

		public GameObject CreateDot() => 
			_assets.Instantiate(AssetPath.DotPath);

		public GameObject CreateCircle() => 
			_assets.Instantiate(AssetPath.CirclePath);
	}
}
