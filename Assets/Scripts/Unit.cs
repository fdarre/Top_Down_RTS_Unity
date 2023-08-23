using UnityEngine;

public class Unit : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private float moveSpeed = 4f;

    #endregion

    #region Update

    private void Update()
    {
        float stoppingDistance = 0.1f;

        if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (_targetPosition - transform.position).normalized;

            transform.position += moveDirection * (moveSpeed * Time.deltaTime);
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

    #endregion
}
