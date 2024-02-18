using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	public class Assets : IAssets
	{
		public GameObject Instantiate(string path)
		{
			GameObject prefab = Resources.Load<GameObject>(path);
			Debug.Log(prefab);
			return Object.Instantiate(prefab);
		}
	}
}