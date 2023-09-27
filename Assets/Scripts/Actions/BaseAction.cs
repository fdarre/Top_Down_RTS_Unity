using TurnBased3DRTS.Units;
using UnityEngine;

namespace TurnBased3DRTS.Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit unit;
        protected bool isActive;

        public delegate void ActionCompleteDelegate();

        protected virtual void Awake()
        {
            unit = GetComponent<Unit>();
        }

        public abstract string GetActionName();
    }
}
