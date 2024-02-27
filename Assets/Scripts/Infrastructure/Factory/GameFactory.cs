using Infrastructure.AssetsManagement;
using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private readonly IAssets _assets;

		public GameObject Dot { get; private set; }
		public GameObject Circle { get; private set; }
		public GameObject Hud { get; set; }

		public GameFactory(IAssets assets) => 
			_assets = assets;

		public void CreateDot() => 
			Dot = _assets.Instantiate(AssetPath.DotPath);

		public void CreateCircle() => 
			Circle = _assets.Instantiate(AssetPath.CirclePath);

		public void CreateHud() =>
			Hud = _assets.Instantiate(AssetPath.HudPath);
	}
}
