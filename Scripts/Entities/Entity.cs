using UnityEngine;
using Sirenix.OdinInspector;

public class Entity : SerializedMonoBehaviour
{
	public virtual void DoAction(string action)
	{
		Debug.Log(action);
	}
}
