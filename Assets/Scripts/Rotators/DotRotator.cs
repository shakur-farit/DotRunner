using Services;
using Zenject;

namespace Rotators
{
	public class DotRotator : Rotator
	{
		private IInputService _inputServiceService;

		[Inject]
		private void Constructor(IAngleSwitcher angleSwitcher, IInputService inputServiceService)
		{
			_angleSwitcher = angleSwitcher;
			_inputServiceService = inputServiceService;
		}

		protected override void Start() =>
			_inputServiceService.IsTaped += SwitchAngle;

		protected override void SwitchAngle() =>
			_zAngle = _angleSwitcher.SwitchAngle(_zAngle);
	}
}