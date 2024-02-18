using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	public interface IAssets
	{
		GameObject Instantiate(string path);
	}
}