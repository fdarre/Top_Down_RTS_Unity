using System.Collections.Generic;
using UnityEngine;
using TurnBased3DRTS.Grid;
using TurnBased3DRTS.Units;

namespace Grid
{
    /// <summary>
    /// The LevelGrid class is responsible for managing the grid system in the game level.
    /// It serves as a central point of interaction for units with the grid.
    /// Singleton Pattern is implemented to ensure there is only one LevelGrid instance.
    /// </summary>
    public class LevelGrid : MonoBehaviour
    {
        #region Singleton Pattern

        /// <summary>
        /// Instance of the LevelGrid class, ensuring a single point of reference.
        /// </summary>
        public static LevelGrid Instance { get; private set; }

        #endregion

        [SerializeField] private Transform _gridDebugObjectPrefab;

        /// <summary>
        /// The GridSystem object that represents the underlying grid structure.
        /// </summary>
        private GridSystem _gridSystem;

        private void Awake()
        {
            // Singleton pattern enforcement
            if (Instance != null)
            {
                Debug.LogError("There is more than one level grid.");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;

            // Initialization of the grid system with specified dimensions and spacing.
            _gridSystem = new GridSystem(10, 10, 2f);
            _gridSystem.CreateDebugObjects(_gridDebugObjectPrefab);
        }

        /// <summary>
        /// Adds a unit to a specific grid position.
        /// </summary>
        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.AddUnit(unit);
        }

        /// <summary>
        /// Retrieves the list of units at a specific grid position.
        /// </summary>
        public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.GetUnitList();
        }

        /// <summary>
        /// Removes a unit from a specific grid position.
        /// </summary>
        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.RemoveUnit(unit);
        }

        /// <summary>
        /// Updates the grid position of a unit when it moves.
        /// </summary>
        public void UnitMovedGridPosition(Unit unit, GridPosition oldGridPosition, GridPosition newGridPosition)
        {
            RemoveUnitAtGridPosition(oldGridPosition, unit);
            AddUnitAtGridPosition(newGridPosition, unit);
        }

        /// <summary>
        /// Converts world position to corresponding grid position.
        /// </summary>
        public GridPosition GetGridPosition(Vector3 worldPosition) => _gridSystem.GetGridPosition(worldPosition);

        /// <summary>
        /// Converts grid position to corresponding world position.
        /// </summary>
        public Vector3 GetWorldPosition(GridPosition gridPosition) => _gridSystem.GetWorldPosition(gridPosition);

        /// <summary>
        /// Checks if a grid position is valid within the grid system.
        /// </summary>
        public bool IsValidGridPosition(GridPosition gridPosition) => _gridSystem.IsValidGridPosition(gridPosition);

        /// <summary>
        /// Checks if any unit is present at a specific grid position.
        /// </summary>
        public bool HasUnitAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.HasAnyUnit();
        }

        /// <summary>
        /// Retrieves the width of the grid.
        /// </summary>
        public int GetWidth() => _gridSystem.GetWidth();

        /// <summary>
        /// Retrieves the height of the grid.
        /// </summary>
        public int GetHeight() => _gridSystem.GetHeight();
    }
}
