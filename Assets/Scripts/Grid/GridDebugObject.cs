using TMPro;
using UnityEngine;

namespace Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _textMeshPro;

        private GridObject _gridObject;

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
