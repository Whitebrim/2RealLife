using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Whitebrim
{
	[System.Serializable]
	public class OnMoodChangedEvent : UnityEvent<Mood>
	{
	}

	[Serializable]
	public class MoodSystem
	{
		[ReadOnly, SerializeField]
		public Mood currentMood { get; private set; }
#if UNITY_EDITOR
		[ListItemSelector("SetSelected")]
#endif
		[SerializeField]
		private List<Mood> availableMoods = new List<Mood>();
#if UNITY_EDITOR
		[BoxGroup("Mood Preview"), ShowInInspector, InlineEditor(InlineEditorObjectFieldModes.Hidden)]
		private Mood selectedMood;
#endif
		[PropertySpace]
		public OnMoodChangedEvent OnMoodChanged;
		public void ChangeMood(Mood newMood)
		{
			if (!availableMoods.Contains(newMood))
			{
				throw new ArgumentException("This mood is not available for current entity");
			}
			currentMood = newMood;
			OnMoodChanged.Invoke(currentMood);
			return;
		}

		public void ChangeMood(string newMood)
		{
			Mood mood = availableMoods.Find((x) => x.GetMoodName == newMood);
			if (mood == null)
			{
				throw new ArgumentException("This mood is not available for current entity");
			}

			ChangeMood(mood);
			return;
		}

		public void InitializeMood(Mood mood)
		{
			if (mood == null)
			{
				throw new ArgumentNullException("mood", "Mood is null");
			}
			if (currentMood != null)
			{
				throw new Exception("Currend Mood is already initialized");
			}
			if (!availableMoods.Contains(mood))
			{
				throw new ArgumentException("This mood is not available for current entity");
			}

			ChangeMood(mood);
			return;
		}

		public Mood GetMood(string mood)
		{
			return availableMoods.Find((x) => x.GetMoodName == mood);
		}

#if UNITY_EDITOR
        #region EditorPreview

		public void SetSelected(int index)
		{
			this.selectedMood = index >= 0 ? this.availableMoods[index] : null;
		}

        #endregion
        public void ValidateMoods()
		{
			availableMoods = availableMoods.Distinct().Where((x) => x != null).ToList();
		}

		public void CheckAvailableAction(ActionType action)
		{
			foreach (var mood in availableMoods)
			{
				if (mood != null)
				{
					if (mood.consequences == null)
					{
						mood.consequences = new Dictionary<ActionType, Consequence>();
					}

					if (!mood.consequences.ContainsKey(action))
					{
						mood.consequences.Add(action, new Consequence());
					}
				}
			}
		}

		public void CheckExtraActions(ref List<ActionType> actions)
		{
			foreach (var mood in availableMoods)
			{
				if (mood != null)
				{
					while (RemoveExtra(mood, ref actions)) ;
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

		private bool RemoveExtra(Mood mood, ref List<ActionType> actions)
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
}