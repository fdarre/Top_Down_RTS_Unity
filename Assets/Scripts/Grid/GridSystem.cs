using Grid;
using UnityEngine;

public class GridSystem
{
   private int _width;
   private int _height;
   private float _cellSize;
   private GridObject[,] _gridObjectsArray2D;

   public GridSystem(int width, int height, float cellSize)
   {
      _width = width;
      _height = height;
      _cellSize = cellSize;

      _gridObjectsArray2D = new GridObject[_width, _height];

      for (int x = 0; x < _width; x++)
      {
         for (int z = 0; z < _height; z++)
         {
            GridPosition gridPosition = new GridPosition(x, z);
            _gridObjectsArray2D[x, z] = new GridObject(this, gridPosition);
         }
      }

   }

   public Vector3 GetWorldPosition(GridPosition gridPosition)
   {
      return new Vector3(gridPosition.X, 0, gridPosition.Z) * _cellSize;
   }

   public GridPosition GetGridPosition(Vector3 worldPosition)
   {
      return new GridPosition(
         Mathf.RoundToInt(worldPosition.x / _cellSize),
         Mathf.RoundToInt(worldPosition.z / _cellSize)
      );

   }

   public void CreateDebugObjects(Transform debugPrefab)
   {
      for (int x = 0; x < _width; x++)
      {
         for (int z = 0; z < _height; z++)
         {
            GridPosition gridPosition = new GridPosition(x, z);

            Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
            GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
            gridDebugObject.SetGridObject(GetGridObject(gridPosition));
         }
      }
   }

   public GridObject GetGridObject(GridPosition gridPosition)
   {
      return _gridObjectsArray2D[gridPosition.X, gridPosition.Z];
   }
}
