using Infrastructure.Services;
using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Rotators
{
	public class DotRotator : Rotator
	{
		private IInputService _inputService;

		[Inject]
		public void Constructor(IAngleSwitcherService angleSwitcherService, IInputService inputService)
		{
			AngleSwitcherService = angleSwitcherService;
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
			ZAngle = AngleSwitcherService.SwitchAngle(ZAngle);
	}
}