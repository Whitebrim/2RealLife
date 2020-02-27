using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Mood : SerializedScriptableObject
{
	[SerializeField] private string moodName;
	[DictionaryDrawerSettings(IsReadOnly = true)] public Dictionary<Action, ActionScript> consequences = new Dictionary<Action, ActionScript>();

	public string GetMoodName
	{
		get { return moodName; }
		protected set { moodName = value; }
	}

#if UNITY_EDITOR
	public void OnValidate()
	{
		foreach (var consequence in consequences)
		{
			if (consequence.Value == null)
				Debug.LogError("Consequence is Null", this);
		}
	}
#endif
}