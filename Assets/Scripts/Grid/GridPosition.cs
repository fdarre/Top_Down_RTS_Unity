using System;

namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents a position within the GridSystem using X and Z coordinates.
    /// </summary>
    public struct GridPosition: IEquatable<GridPosition>
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

        /// <summary>
        /// Returns a string representation of the GridPosition.
        /// </summary>
        public override string ToString()
        {
            return $"(x: {X}, z:{Z})";
        }

        /// <summary>
        /// Determines if two GridPosition instances are equal.
        /// </summary>
        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return a.X == b.X && a.Z == b.Z;
        }

        /// <summary>
        /// Determines if two GridPosition instances are not equal.
        /// </summary>
        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Determines if the current GridPosition instance is equal to another GridPosition instance.
        /// </summary>
        public bool Equals(GridPosition other)
        {
            return X == other.X && Z == other.Z;
        }

        /// <summary>
        /// Determines if the current GridPosition instance is equal to an object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is GridPosition other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for the current GridPosition instance.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Z);
        }
    }
}
