using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class Cat : Entity
{
	[SerializeField] private List<Action> availableActions;
	[SerializeField] public MoodSystem mood { get; private set; }
	[SerializeField] private TextMeshProUGUI log;

	private void Awake()
	{
		mood.InitializeMood(mood.GetMood("Good"));
	}

	public void ApplyAction(Action action)
	{
		if (availableActions.Contains(action))
		{
			mood.currentMood.consequences[action].Execute(this);
		}
	}
	public override void DoAction(string action)
	{
		log.text += "\nКошка: " + action;
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		mood.ValidateMoods();
		availableActions = availableActions.Distinct().Where((x) => x != null).ToList();
		if (availableActions != null && availableActions.Count > 0)
		{
			foreach (var action in availableActions)
			{
				if (action != null)
					mood.CheckAvailableAction(action);
			}
		}
		mood.CheckExtraActions(ref availableActions);
		mood.NotifyOnValidate();
	}
#endif
}
