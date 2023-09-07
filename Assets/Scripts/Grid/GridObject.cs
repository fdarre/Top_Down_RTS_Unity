public class GridObject
{
    private GridPosition _gridPosition;
    private GridSystem _gridSystem;

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
