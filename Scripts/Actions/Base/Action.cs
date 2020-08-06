using Sirenix.OdinInspector;
using UnityEngine;

namespace Whitebrim
{
    [CreateAssetMenu]
    public class Action : SerializedScriptableObject
    {
        public IAction action;
        public ActionType actionType;

        public void Execute(Entity sender, Entity victim)
        {
            action.Execute(sender, victim);
        }
    }
}