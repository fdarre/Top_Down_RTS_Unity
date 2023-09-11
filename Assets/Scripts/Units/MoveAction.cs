using System.Collections.Generic;
using Grid;
using TurnBased3DRTS.Grid;
using TurnBased3DRTS.Units;
using UnityEngine;

namespace Units
{
    public class MoveAction : MonoBehaviour
    {
        #region Fields

        [Tooltip("Speed at which the unit moves.")]
        [SerializeField] private float _moveSpeed = 4f;

        [Tooltip("Maximum distance the unit can move in a single turn.")]
        [SerializeField] private int _maxMoveDistance = 4;

        [Tooltip("Hash for the 'IsWalking' animator parameter.")]
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        [Tooltip("Speed at which the unit rotates to face its direction.")]
        private float _rotationSpeed = 12f;

        private Vector3 _targetPosition;
        private Animator _animator;
        private Unit _unit;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _targetPosition = transform.position;
            _animator = GetComponentInChildren<Animator>();
            _unit = GetComponent<Unit>();
        }

        private void Update()
        {
            float stoppingDistance = 0.1f;

            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                _animator.SetBool(IsWalking, true);

                Vector3 moveDirection = (_targetPosition - transform.position).normalized;

                transform.position += moveDirection * (_moveSpeed * Time.deltaTime);
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * _rotationSpeed);
            }
            else
            {
                _animator.SetBool(IsWalking, false);
            }
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Directs the unit to move towards the specified target position.
        /// </summary>
        /// <param name="targetPosition">The position to move towards.</param>
        public void Move(GridPosition targetPosition)
        {
            _targetPosition = LevelGrid.Instance.GetWorldPosition(targetPosition);
        }

        public List<GridPosition> GetValidGridPositionsList()
        {
            List<GridPosition> validGridPositionsList = new List<GridPosition>();
            GridPosition unitGridPosition = _unit.GetGridPosition();

            for (int x = -_maxMoveDistance; x < _maxMoveDistance; x++)
            {
                for (int z = -_maxMoveDistance; z < _maxMoveDistance; z++)
                {
                    GridPosition offsetGridPosition = new GridPosition(x, z);
                    GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                    if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition)) continue;
                    if(LevelGrid.Instance.HasUnitAtGridPosition(testGridPosition)) continue;
                    if (unitGridPosition == testGridPosition) continue;

                    validGridPositionsList.Add(testGridPosition);
                }

            }

            return validGridPositionsList;
        }

        public bool IsValidMovePosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionsList = GetValidGridPositionsList();
            return validGridPositionsList.Contains(gridPosition);
        }

        #endregion
    }
}