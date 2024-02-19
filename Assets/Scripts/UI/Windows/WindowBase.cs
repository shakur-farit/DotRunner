using System;
using UnityEngine;

namespace UI.Windows
{
	public abstract class WindowBase : MonoBehaviour
	{
		private void Awake() => 
			OnAwake();

		protected virtual void OnAwake()
		{
			
		}
	}
}
