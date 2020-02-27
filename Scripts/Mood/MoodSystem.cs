using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnMoodChangedEvent : UnityEvent<Mood>
{
}

[Serializable]
public class MoodSystem
{
	[ReadOnly] [SerializeField] public Mood currentMood { get; private set; }
	[SerializeField] private List<Mood> availableMoods = new List<Mood>();
	public OnMoodChangedEvent OnMoodChanged;
	public void ChangeMood(Mood newMood)
	{
		if (availableMoods.Contains(newMood))
		{
			currentMood = newMood;
			OnMoodChanged.Invoke(currentMood);
			return;
		}
		throw new ArgumentException("This mood is not available for current entity");
	}

	public void ChangeMood(string newMood)
	{
		Mood mood = availableMoods.Find((x) => x.GetMoodName == newMood);
		if (mood!=null)
		{
			ChangeMood(mood);
			return;
		}
		throw new ArgumentException("This mood is not available for current entity");
	}

	public void InitializeMood(Mood mood)
	{
		if(mood != null)
		{
			if (currentMood == null)
			{
				if (availableMoods.Contains(mood))
				{
					ChangeMood(mood);
					return;
				}
				throw new ArgumentException("This mood is not available for current entity");
			}
			else
			{
				throw new Exception("Currend Mood is already initialized");
			}
		}
		throw new ArgumentNullException("mood", "Mood is null");
	}

	public Mood GetMood(string mood)
	{
		return availableMoods.Find((x) => x.GetMoodName == mood);
	}

#if UNITY_EDITOR
	public void ValidateMoods()
	{
		availableMoods = availableMoods.Distinct().Where((x) => x != null).ToList();
	}

	public void CheckAvailableAction(Action action)
	{
		foreach (var mood in availableMoods)
		{
			if (mood != null)
			{
				if (mood.consequences == null)
					mood.consequences = new Dictionary<Action, ActionScript>();

				if (!mood.consequences.ContainsKey(action))
				{
					mood.consequences.Add(action, null);
				}
			}
		}
	}

	public void CheckExtraActions(ref List<Action> actions)
	{
		foreach (var mood in availableMoods)
		{
			if (mood != null)
			{
				while (RemoveExtra(mood, ref actions));
			}
		}
	}

	public void NotifyOnValidate()
	{
		foreach (var mood in availableMoods)
		{
			mood.OnValidate();
		}
	}

	private bool RemoveExtra(Mood mood, ref List<Action> actions)
	{
		foreach (var consequence in mood.consequences)
		{
			if (actions == null || !actions.Contains(consequence.Key))
			{
				mood.consequences.Remove(consequence.Key);
				return true;
			}
		}
		return false;
	}
#endif
}
