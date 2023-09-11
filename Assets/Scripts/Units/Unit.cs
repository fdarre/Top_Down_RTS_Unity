using Grid;
using TurnBased3DRTS.Grid;
using Units;
using UnityEngine;

namespace TurnBased3DRTS.Units
{
    /// <summary>
    /// Represents a unit with movement capabilities. The unit can be directed to move towards a target position.
    /// </summary>
    public class Unit : MonoBehaviour
    {
        #region Fields

        private GridPosition _gridPosition;
        private MoveAction _moveAction;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _moveAction = GetComponent<MoveAction>();
        }

        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
        }

        private void Update()
        {
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newGridPosition != _gridPosition)
            {
                LevelGrid.Instance.UnitMovedGridPosition(this, _gridPosition, newGridPosition);
                _gridPosition = newGridPosition;
            }
        }

        #endregion

        #region Custom Methods

        public MoveAction GetMoveAction()
        {
            return _moveAction;
        }

        #endregion
    }
}