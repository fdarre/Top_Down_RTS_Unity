using UnityEngine;

namespace TurnBased3DRTS.Units
{
    /// <summary>
    /// Represents a unit with movement capabilities. The unit can be directed to move towards a target position.
    /// </summary>
    public class Unit : MonoBehaviour
    {
        #region Serialized Fields

        [Tooltip("Speed at which the unit moves.")]
        [SerializeField] private float moveSpeed = 4f;

        #endregion

        #region Private Fields

        private Vector3 _targetPosition;
        private Animator _animator;

        [Tooltip("Hash for the 'IsWalking' animator parameter.")]
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        [Tooltip("Speed at which the unit rotates to face its direction.")]
        private float _rotationSpeed = 12f;

        #endregion

        #region Initialization

        private void Awake()
        {
            _targetPosition = transform.position;
            _animator = GetComponentInChildren<Animator>();
        }

        #endregion

        #region Update

        private void Update()
        {
            float stoppingDistance = 0.1f;

            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                _animator.SetBool(IsWalking, true);

                Vector3 moveDirection = (_targetPosition - transform.position).normalized;

                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
                transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * _rotationSpeed);
            }
            else
            {
                _animator.SetBool(IsWalking, false);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Directs the unit to move towards the specified target position.
        /// </summary>
        /// <param name="targetPosition">The position to move towards.</param>
        public void Move(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        #endregion
    }
}
