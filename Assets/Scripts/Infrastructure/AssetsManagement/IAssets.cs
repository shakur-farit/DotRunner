using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	public interface IAssets
	{
		GameObject Instantiate(string path);
		GameObject Instantiate(string path, Transform parentTransform);
	}
}