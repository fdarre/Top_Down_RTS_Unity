using UnityEngine;

namespace TurnBased3DRTS.Controls
{
    /// <summary>
    /// Handles mouse interactions within the game world, specifically providing world positions based on mouse cursor placement.
    /// </summary>
    public class MouseWorld : MonoBehaviour
    {
        #region Initialization

        private void Awake()
        {
            _instance = this;
        }

        #endregion

        #region Update

        private void Update()
        {
            transform.position = GetPosition();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Retrieves the world position of the mouse cursor based on a raycast.
        /// </summary>
        /// <returns>The world position where the mouse ray intersects the MousePlane layer. Returns Vector3.zero if no intersection.</returns>
        public static Vector3 GetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("MousePlane")))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        /// <summary>
        /// Retrieves the world position of the mouse cursor based on a raycast, specifically for the MousePlane layer.
        /// </summary>
        /// <returns>The world position where the mouse ray intersects the MousePlane layer. Returns Vector3.zero if no intersection.</returns>
        public static Vector3 GetMousePlanePosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("MousePlane")))
            {
                return hit.point;
            }

            return Vector3.zero;
        }

        #endregion

        #region Private Fields

        private static MouseWorld _instance;

        #endregion
    }
}
