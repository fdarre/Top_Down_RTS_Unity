using System;
using UnityEngine;

namespace TurnBased3DRTS.Units
{
    /// <summary>
    /// Provides visual feedback for when a unit is selected.
    /// Enables or disables the attached MeshRenderer based on the unit's selection status.
    /// </summary>
    public class UnitSelectedVisual : MonoBehaviour
    {
        #region Serialized Fields

        [Tooltip("Reference to the unit that this visual feedback is attached to.")]
        [SerializeField] private Unit unit;

        #endregion

        #region Private Fields

        private MeshRenderer _meshRenderer;

        #endregion

        #region Initialization

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
            UpdateVisual();
        }

        #endregion

        #region Event Callbacks

        /// <summary>
        /// Handles the event when a unit is selected in the UnitActionSystem. Updates the visual feedback.
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="empty">Empty event arguments.</param>
        private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            UpdateVisual();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates the visual feedback based on the currently selected unit in the UnitActionSystem.
        /// </summary>
        private void UpdateVisual()
        {
            Debug.Log("UnitActionSystem_OnSelectedUnitChanged - " + UnitActionSystem.Instance.SelectedUnit.name);

            if (UnitActionSystem.Instance.SelectedUnit == unit)
            {
                _meshRenderer.enabled = true;
            }
            else
            {
                _meshRenderer.enabled = false;
            }
        }

        #endregion
    }
}
