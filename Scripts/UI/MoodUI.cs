using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

namespace Whitebrim.UI
{
	public class MoodUI : SerializedMonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI moodText;
		[SerializeField] private Image moodImage;
		[SerializeField] Dictionary<Mood, Color32> palette = new Dictionary<Mood, Color32>();
		public void OnMoodChanged(Mood newMood)
		{
			moodText.text = newMood.GetMoodName;
			if (palette.TryGetValue(newMood, out Color32 color))
			{
				moodImage.color = color;
			}
			else
			{
				moodImage.color = Color.black;
			}
		}
	}
}