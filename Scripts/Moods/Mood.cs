using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Whitebrim
{
	[CreateAssetMenu]
	public class Mood : SerializedScriptableObject
	{
		[SerializeField]
		private string moodName;
		[DictionaryDrawerSettings(IsReadOnly = true)]
		public Dictionary<ActionType, Consequence> consequences = new Dictionary<ActionType, Consequence>();

		public string GetMoodName
		{
			get { return moodName; }
			protected set { moodName = value; }
		}

	#if UNITY_EDITOR
		public void OnValidate()
		{
			if (string.IsNullOrEmpty(moodName))
			{
				moodName = name;
			}
		}
	#endif
	}
}