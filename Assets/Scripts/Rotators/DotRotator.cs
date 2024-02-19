using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Rotators
{
	public class DotRotator : Rotator
	{
		private IInputService _inputService;

		[Inject]
		public void Constructor(IAngleSwitcher angleSwitcher, IInputService inputService)
		{
			AngleSwitcher = angleSwitcher;
			_inputService = inputService;
		}

		protected override void Start() =>
			_inputService.IsTaped += SwitchAngle;

		protected override void OnDestroy() => 
			_inputService.IsTaped -= SwitchAngle;

		protected override void Update()
		{
			base.Update();

			_inputService.Tap();
		}

		protected override void SwitchAngle() =>
			ZAngle = AngleSwitcher.SwitchAngle(ZAngle);
	}
}