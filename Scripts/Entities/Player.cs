using TMPro;
using UnityEngine;

public class Player : Entity
{
	[SerializeField] private Cat cat;
	[SerializeField] private TextMeshProUGUI log;

	public void ApplyAction(Action action)
	{
		action.script.Execute(this);
		cat.ApplyAction(action);
	}

	public override void DoAction(string action)
	{
		log.text = "Игрок: " + action;
	}
}
