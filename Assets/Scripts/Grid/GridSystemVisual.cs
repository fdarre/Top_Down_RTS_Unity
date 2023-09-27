using System.Collections.Generic;
using TurnBased3DRTS.Grid;
using TurnBased3DRTS.Units;
using UnityEngine;

namespace Grid
{
    /// <summary>
    /// The GridSystemVisual class is responsible for visualizing the grid system in the game world.
    /// It keeps track of individual visuals for each grid position, allowing for dynamic updating of the grid based on unit actions.
    /// </summary>
    public class GridSystemVisual : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of GridSystemVisual.
        /// </summary>
        public static GridSystemVisual Instance { get; private set; }

        /// <summary>
        /// Prefab used to instantiate visuals for each grid position.
        /// </summary>
        [SerializeField]
        private Transform _gridSystemVisualPrefab;

        /// <summary>
        /// 2D array to store individual visuals for each grid position.
        /// </summary>
        private GridSystemVisualSingle[,] _gridSystemVisualSingleArray;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one grid System visual.");
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            InitializeGridVisuals();
        }

        private void Update()
        {
            UpdateGridVisual();
        }

        /// <summary>
        /// Initializes the grid visuals based on the grid size and instantiates them in the game world.
        /// </summary>
        private void InitializeGridVisuals()
        {
            _gridSystemVisualSingleArray = new GridSystemVisualSingle[
                LevelGrid.Instance.GetWidth(),
                LevelGrid.Instance.GetHeight()
            ];

            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
                {
                   GridPosition gridPosition = new GridPosition(x, z);
                   Transform  gridSystemVisualSingleTransform = Instantiate(_gridSystemVisualPrefab, LevelGrid.Instance.GetWorldPosition(gridPosition),
                       Quaternion.identity);
                   _gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.GetComponent<GridSystemVisualSingle>();
                }
            }
        }

        /// <summary>
        /// Hides visuals for all grid positions.
        /// </summary>
        public void HideAllGridPositionsVisuals()
        {
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for(int z = 0; z < LevelGrid.Instance.GetHeight(); z++)
                {
                    _gridSystemVisualSingleArray[x, z].Hide();
                }
            }
        }

        /// <summary>
        /// Shows visuals for a list of specified grid positions.
        /// </summary>
        /// <param name="gridPositionList">List of grid positions to show.</param>
        public void ShowGridPositionList(List<GridPosition> gridPositionList)
        {
            foreach (GridPosition gridPosition in gridPositionList)
            {
                _gridSystemVisualSingleArray[gridPosition.X, gridPosition.Z].Show();
            }
        }

        /// <summary>
        /// Updates the grid visual based on the current selected unit and its valid movement positions.
        /// </summary>
        private void UpdateGridVisual()
        {
            Unit selectedUnit = UnitActionSystem.Instance.SelectedUnit;
            HideAllGridPositionsVisuals();
            ShowGridPositionList(selectedUnit.GetMoveAction().GetValidGridPositionsList());
        }
    }
}
