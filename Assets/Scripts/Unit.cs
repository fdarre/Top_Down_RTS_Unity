using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float moveSpeed = 4f;

    #endregion

    #region Initialization

    private void Awake()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            Move(MouseWorld.GetPosition());
        }
    }

    #endregion

    #region Private Methods

    private void Move(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    #endregion

    #region Private Fields

    private Vector3 _targetPosition;
    private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private float _rotationSpeed = 12f;

    #endregion
}
