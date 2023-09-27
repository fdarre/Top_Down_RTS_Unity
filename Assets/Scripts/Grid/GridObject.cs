using System.Collections.Generic;
using TurnBased3DRTS.Units;

namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// The GridObject class represents a single object within the GridSystem.
    /// It maintains a reference to its position in the grid and contains a list of units that are currently occupying this grid position.
    /// </summary>
    public class GridObject
    {
        /// <summary>
        /// The position of this GridObject within the grid.
        /// </summary>
        private GridPosition _gridPosition;

        /// <summary>
        /// The GridSystem to which this GridObject belongs.
        /// </summary>
        private GridSystem _gridSystem;

        /// <summary>
        /// The list of units currently occupying this grid position.
        /// </summary>
        private List<Unit> _unitList;

        /// <summary>
        /// Initializes a new instance of the GridObject class.
        /// </summary>
        /// <param name="gridSystem">The GridSystem to which this object belongs.</param>
        /// <param name="gridPosition">The position of this object within the grid.</param>
        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            _gridSystem = gridSystem;
            _gridPosition = gridPosition;
            _unitList = new List<Unit>();
        }

        /// <summary>
        /// Returns a string representation of the GridObject, including its position and the names of the units occupying it.
        /// </summary>
        public override string ToString()
        {
            string unitListString = "";
            foreach (Unit unit in _unitList)
            {
                unitListString += unit.name + "\n";
            }
            return _gridPosition + "\n" + unitListString;
        }

        /// <summary>
        /// Adds a unit to the GridObject's unit list.
        /// </summary>
        /// <param name="unit">The unit to be added.</param>
        public void AddUnit(Unit unit)
        {
            _unitList.Add(unit);
        }

        /// <summary>
        /// Removes a unit from the GridObject's unit list.
        /// </summary>
        /// <param name="unit">The unit to be removed.</param>
        public void RemoveUnit(Unit unit)
        {
            _unitList.Remove(unit);
        }

        /// <summary>
        /// Retrieves the list of units currently occupying this GridObject.
        /// </summary>
        public List<Unit> GetUnitList()
        {
            return _unitList;
        }

        /// <summary>
        /// Determines whether any units are currently occupying this GridObject.
        /// </summary>
        public bool HasAnyUnit()
        {
            return _unitList.Count > 0;
        }
    }
}
