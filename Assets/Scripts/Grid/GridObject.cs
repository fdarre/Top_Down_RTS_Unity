using System.Collections.Generic;
using TurnBased3DRTS.Units;

namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents an object within the GridSystem, containing a reference to its position and the system it belongs to.
    /// </summary>
    public class GridObject
    {
        private GridPosition _gridPosition;
        private GridSystem _gridSystem;
        private List<Unit> _unitList;

        /// <summary>
        /// Initializes a new instance of GridObject with the given GridSystem and GridPosition.
        /// </summary>
        /// <param name="gridsystem">The GridSystem this object belongs to.</param>
        /// <param name="gridposition">The position of this object within the grid.</param>
        public GridObject(GridSystem gridsystem, GridPosition gridposition)
        {
            _gridSystem = gridsystem;
            _gridPosition = gridposition;
            _unitList = new List<Unit>();
        }

        public override string ToString()
        {
            string unitListString = "";

            foreach (Unit unit in _unitList)
            {
                unitListString += unit.name + "\n";
            }

            return _gridPosition + "\n" + unitListString;
        }

        public void AddUnit(Unit unit)
        {
            _unitList.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            _unitList.Remove(unit);
        }

        public List<Unit> GetUnitList()
        {
            return _unitList;
        }
    }
}