using UnityEngine;
using TMPro;

namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents a visual debug object for the GridObject within the GridSystem in Unity's ECS.
    /// </summary>
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMeshPro;

        private GridObject _gridObject;

        /// <summary>
        /// Sets the associated GridObject for this debug object.
        /// </summary>
        /// <param name="gridObject">The GridObject to associate with.</param>
        public void SetGridObject(GridObject gridObject)
        {
            this._gridObject = gridObject;
        }

        private void Update()
        {
            _textMeshPro.text = _gridObject.ToString();
        }
    }
}