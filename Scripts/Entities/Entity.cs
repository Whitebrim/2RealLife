using UnityEngine;
using Sirenix.OdinInspector;

namespace Whitebrim
{
	public class Entity : SerializedMonoBehaviour
	{
		public virtual void DoAction(string action)
		{
			Debug.Log(action);
		}
	}
}