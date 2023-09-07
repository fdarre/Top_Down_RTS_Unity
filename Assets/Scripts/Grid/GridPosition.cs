//using custom struct instead of Vector2Int struct to work with x, z instead of x, y
public struct GridPosition
{
    public int X { get; private set; }
    public int Z { get; private set; }

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
