namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents a position within the GridSystem using X and Z coordinates.
    /// </summary>
    public struct GridPosition
    {
        public int X { get; private set; }
        public int Z { get; private set; }

        /// <summary>
        /// Initializes a new instance of GridPosition with the given X and Z coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="z">The Z coordinate.</param>
        public GridPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        public override string ToString()
        {
            return $"(x: {X}, z:{Z})";
        }
    }
}