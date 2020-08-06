using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Whitebrim
{
	public class Player : Entity
	{
		[SerializeField] private Cat cat;
		[SerializeField] private TextMeshProUGUI log;
		public List<Action> availableActions = new List<Action>();

		public void ApplyAction(Action action)
		{
			action.Execute(this, cat);
			cat.ApplyAction(action.actionType, this);
		}

		public override void DoAction(string action)
		{
			log.text = "Игрок: " + action;
		}
	}
}