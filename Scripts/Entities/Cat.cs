using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace Whitebrim
{
	public class Cat : Entity
	{
#if UNITY_EDITOR
		[ListItemSelector("SetSelected")]
#endif
		[ SerializeField]
		private List<ActionType> availableActions;
#if UNITY_EDITOR
		[BoxGroup("Action Type Preview"), ShowInInspector, InlineEditor(InlineEditorObjectFieldModes.Hidden)]
		private ActionType selectedActionType;
#endif
		[SerializeField]
		public MoodSystem mood { get; private set; }
		[SerializeField, PropertySpace(spaceBefore: 10, spaceAfter: 10)]
		private TextMeshProUGUI log;

		private void Awake()
		{
			if(mood.currentMood == null)
				mood.InitializeMood(mood.GetMood("Good"));
		}

		public void ApplyAction(ActionType actionType, Entity sender)
		{
			if (availableActions.Contains(actionType))
            {
				Consequence consequence = mood.currentMood.consequences[actionType];
				consequence.onActionApplied.Invoke(this, sender);
				if (consequence.changeMood)
					mood.ChangeMood(consequence.newMood);
            }
			else
				Debug.LogError("Cat doesn't know how to respond to Action: " + actionType.name);
		}
		public override void DoAction(string action)
		{
			log.text += "\nКошка: " + action;
		}

#if UNITY_EDITOR
		#region EditorPreview

		public void SetSelected(int index)
		{
			this.selectedActionType = index >= 0 ? this.availableActions[index] : null;
		}

		#endregion
		private void OnValidate()
		{
			mood.ValidateMoods();
			availableActions = availableActions.Distinct().Where((x) => x != null).ToList();
			if (availableActions != null && availableActions.Count > 0)
			{
				foreach (var actionType in availableActions)
				{
					if (actionType != null)
					{
						mood.CheckAvailableAction(actionType);
					}
				}
			}
			mood.CheckExtraActions(ref availableActions);
			mood.NotifyOnValidate();
		}
#endif
	}
}