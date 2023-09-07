namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents an object within the GridSystem, containing a reference to its position and the system it belongs to.
    /// </summary>
    public class GridObject
    {
        private GridPosition _gridPosition;
        private GridSystem _gridSystem;

        /// <summary>
        /// Initializes a new instance of GridObject with the given GridSystem and GridPosition.
        /// </summary>
        /// <param name="gridsystem">The GridSystem this object belongs to.</param>
        /// <param name="gridposition">The position of this object within the grid.</param>
        public GridObject(GridSystem gridsystem, GridPosition gridposition)
        {
            _gridSystem = gridsystem;
            _gridPosition = gridposition;
        }

        public override string ToString()
        {
            return _gridPosition.ToString();
        }
    }
}