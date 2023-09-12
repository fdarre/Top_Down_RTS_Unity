using System.Collections.Generic;
using UnityEngine;
using TurnBased3DRTS.Grid;
using TurnBased3DRTS.Units;


namespace Grid
{
    public class LevelGrid : MonoBehaviour
    {
        #region Singleton Pattern

        public static LevelGrid Instance { get; private set; }

        #endregion

        [SerializeField] private Transform _gridDebugObjectPrefab;

        private GridSystem _gridSystem;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one level grid.");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;

            _gridSystem = new GridSystem(10, 10, 2f);
            _gridSystem.CreateDebugObjects(_gridDebugObjectPrefab);

        }

        public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.AddUnit(unit);
        }

        public List<Unit> GetUnitListAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.GetUnitList();
        }

        public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            gridObject.RemoveUnit(unit);
        }

        public void UnitMovedGridPosition(Unit unit, GridPosition oldGridPosition, GridPosition newGridPosition)
        {
            RemoveUnitAtGridPosition(oldGridPosition, unit);
            AddUnitAtGridPosition(newGridPosition, unit);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition) => _gridSystem.GetGridPosition(worldPosition);
        public Vector3 GetWorldPosition(GridPosition gridPosition) => _gridSystem.GetWorldPosition(gridPosition);

        /// <summary>
        /// Checks if a grid position is valid.
        /// </summary>
        public bool IsValidGridPosition(GridPosition gridPosition) => _gridSystem.IsValidGridPosition(gridPosition);

        public bool HasUnitAtGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
            return gridObject.HasAnyUnit();
        }

        public int GetWidth() => _gridSystem.GetWidth();
        public int GetHeight() => _gridSystem.GetHeight();
    }
}
