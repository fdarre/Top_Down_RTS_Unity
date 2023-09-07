using UnityEngine;

namespace TurnBased3DRTS.Grid
{
    /// <summary>
    /// Represents a 2D grid system in 3D space, with utilities for world and grid position conversion.
    /// </summary>
    public class GridSystem
    {
        private int _width;
        private int _height;
        private float _cellSize;
        private GridObject[,] _gridObjectsArray2D;

        /// <summary>
        /// Initializes a new instance of the GridSystem with the given dimensions and cell size.
        /// </summary>
        /// <param name="width">Width of the grid.</param>
        /// <param name="height">Height of the grid.</param>
        /// <param name="cellSize">Size of each cell in the grid.</param>
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

        /// <summary>
        /// Converts a grid position to its corresponding world position.
        /// </summary>
        /// <param name="gridPosition">The grid position to be converted.</param>
        /// <returns>The world position equivalent of the grid position.</returns>
        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.X, 0, gridPosition.Z) * _cellSize;
        }

        /// <summary>
        /// Converts a world position to its corresponding grid position.
        /// </summary>
        /// <param name="worldPosition">The world position to be converted.</param>
        /// <returns>The grid position equivalent of the world position.</returns>
        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(
                Mathf.RoundToInt(worldPosition.x / _cellSize),
                Mathf.RoundToInt(worldPosition.z / _cellSize)
            );
        }

        /// <summary>
        /// Creates and positions debug objects at each grid position.
        /// </summary>
        /// <param name="debugPrefab">The prefab used for the debug objects.</param>
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

        /// <summary>
        /// Retrieves the GridObject located at a specific grid position.
        /// </summary>
        /// <param name="gridPosition">The position in the grid to get the GridObject from.</param>
        /// <returns>The GridObject at the given grid position.</returns>
        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return _gridObjectsArray2D[gridPosition.X, gridPosition.Z];
        }
    }
}