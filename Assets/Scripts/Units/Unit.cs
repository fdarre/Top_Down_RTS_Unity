using TurnBased3DRTS.Actions;
using Grid;
using TurnBased3DRTS.Grid;
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
        private SpinAction _spinAction;
        private BaseAction[] _baseActionsArray;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _moveAction = GetComponent<MoveAction>();
            _spinAction = GetComponent<SpinAction>();
            _baseActionsArray = GetComponents<BaseAction>();
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

        public SpinAction GetSpinAction()
        {
            return _spinAction;
        }

        public GridPosition GetGridPosition()
        {
            return _gridPosition;
        }

        public BaseAction[] GetBaseActionsArray()
        {
            return _baseActionsArray;
        }

        #endregion
    }
}