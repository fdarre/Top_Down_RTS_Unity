using System.Collections.Generic;
using TurnBased3DRTS.Grid;
using TurnBased3DRTS.Units;
using UnityEngine;

namespace Grid
{
    public class GridSystemVisual : MonoBehaviour
    {
        public static GridSystemVisual Instance { get; private set; }

        [SerializeField] private Transform _gridSystemVisualPrefab;

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

        private void Update()
        {
            UpdateGridVisual();
        }

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

        public void ShowGridPositionList(List<GridPosition> gridPositionList)
        {
            foreach (GridPosition gridPosition in gridPositionList)
            {
                _gridSystemVisualSingleArray[gridPosition.X, gridPosition.Z].Show();
            }
        }

        private void UpdateGridVisual()
        {
            Unit selectedUnit = UnitActionSystem.Instance.SelectedUnit;
            HideAllGridPositionsVisuals();
            ShowGridPositionList(selectedUnit.GetMoveAction().GetValidGridPositionsList());
        }
    }
}
