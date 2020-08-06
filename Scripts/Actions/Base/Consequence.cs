using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Whitebrim
{
    public struct Consequence
    {
        public ConsequenceEvent onActionApplied;
        [ToggleLeft] public bool changeMood;
        [ShowIf("changeMood")] public Mood newMood;
    }

    [System.Serializable]
    public class ConsequenceEvent : UnityEvent<Entity, Entity>
    {
    }
}