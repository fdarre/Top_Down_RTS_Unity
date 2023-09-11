using UnityEngine;

public class MoveAction : MonoBehaviour
{
    #region Fields

    [Tooltip("Speed at which the unit moves.")]
    [SerializeField] private float moveSpeed = 4f;

    [Tooltip("Hash for the 'IsWalking' animator parameter.")]
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    [Tooltip("Speed at which the unit rotates to face its direction.")]
    private float _rotationSpeed = 12f;

    private Vector3 _targetPosition;
    private Animator _animator;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _targetPosition = transform.position;
        _animator = GetComponentInChildren<Animator>();
    }

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

    #region Custom Methods

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