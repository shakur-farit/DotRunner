using UnityEngine;
using Zenject;

namespace Infrastructure.AssetsManagement
{
	public class Assets : IAssets
	{
		private readonly DiContainer _diContainer;

		public Assets(DiContainer diContainer) => 
			_diContainer = diContainer;

		public GameObject Instantiate(string path)
		{
			GameObject prefab = Resources.Load<GameObject>(path);
			return _diContainer.InstantiatePrefab(prefab);
		}
	}
}