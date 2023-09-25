using System;
using Grid;
using UnityEngine;
using TurnBased3DRTS.Controls;
using TurnBased3DRTS.Grid;

namespace TurnBased3DRTS.Units
{
    /// <summary>
    /// Handles unit actions and interactions within the game.
    /// Provides functionality for selecting units and issuing commands to them.
    /// </summary>
    public class UnitActionSystem : MonoBehaviour
    {
        #region Singleton Pattern

        /// <summary>
        /// Singleton instance of the UnitActionSystem.
        /// </summary>
        public static UnitActionSystem Instance { get; private set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The currently selected unit in the game.
        /// </summary>
        public Unit SelectedUnit { get; private set; }

        #endregion

        #region Private Fields

        private bool _isBusy;

        #endregion



        #region Events

        /// <summary>
        /// Event triggered when a unit is selected.
        /// </summary>
        public event EventHandler OnSelectedUnitChanged;

        #endregion

        #region Initialization

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one unit action system.");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;

            SelectedUnit = FindAnyObjectByType<Unit>();
        }

        #endregion

        #region Update

        private void Update()
        {
            if(_isBusy) return;

            if (Input.GetMouseButtonDown(0))
            {
                if(TryHandleUnitSelection()) return;

                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());

                if (SelectedUnit.GetMoveAction().IsValidMovePosition(mouseGridPosition))
                {
                    SetBusy();
                    SelectedUnit.GetMoveAction().Move(mouseGridPosition, ClearBusy);
                }

            }

            if (Input.GetMouseButtonDown(1))
            {
                SetBusy();
                SelectedUnit.GetSpinAction().Spin(ClearBusy);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the logic for selecting a unit when clicking on it.
        /// </summary>
        /// <returns>True if a unit was selected, otherwise false.</returns>
        private bool TryHandleUnitSelection()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("Units")))
            {
                if(hit.collider.TryGetComponent(out Unit clickedUnit))
                {
                    SetSelectedUnit(clickedUnit);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sets the currently selected unit.
        /// </summary>
        /// <param name="unit">The unit to be set as the selected unit.</param>
        private void SetSelectedUnit(Unit unit)
        {
            SelectedUnit = unit;

            // Null check to avoid null reference exception if there are no event subscribers
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets the busy flag to true when the unit action system is busy.
        /// </summary>
        private void SetBusy()
        {
            _isBusy = true;
        }

        /// <summary>
        /// Clears the busy flag when the unit action system is no longer busy and ready for another action
        /// </summary>
        private void ClearBusy()
        {
            _isBusy = false;
        }

        #endregion
    }
}
