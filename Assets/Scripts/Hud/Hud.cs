using Infrastructure.Services.TimerService;
using TMPro;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class Hud : MonoBehaviour
	{
		public TextMeshProUGUI ScoreText;
		private ICountUpTimerService _countUpTimer;

		[Inject]
		private void Constructor(ICountUpTimerService countUpTimer) => 
			_countUpTimer = countUpTimer;

		private void Update() => 
			UpdateScoreText();

		private void UpdateScoreText()
		{
			int score = (int)_countUpTimer.CountUpTimeDuration;
			ScoreText.text = score.ToString();
		}
	}
}