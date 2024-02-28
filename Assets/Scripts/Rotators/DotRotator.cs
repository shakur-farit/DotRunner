using Infrastructure.Services.AngleSwitcher;
using Infrastructure.Services.Input;
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

			protected override void OnStart()
			{
				base.OnStart();

				_inputService.IsTaped += SwitchAngle;
			}

			protected override void OnOnDestroy()
			{
				base.OnOnDestroy();

				_inputService.IsTaped -= SwitchAngle;
			}

			protected override void Update()
		{
			base.Update();

			_inputService.Tap();
		}

		protected override void SwitchAngle() =>
			RotateAngle = AngleSwitcherService.SwitchAngle(RotateAngle);
	}
}