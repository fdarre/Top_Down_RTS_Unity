using UnityEngine;
using Cinemachine;

/// <summary>
/// The CameraController class allows for keyboard-driven movement and rotation of the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _moveSpeed = 11f;
    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _zoomAmount = 1f;
    [SerializeField] private float _zoomSpeed = 6f;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private const float MIN_FOLLOW_OFFSET_Y = 2f;
    private const float MAX_FOLLOW_OFFSET_Y = 13f;

    private CinemachineTransposer _cinemachineTransposer;
    private Vector3 _targetFollowOffset;


    #endregion

    #region Unity Methods

    private void Start()
    {
        _cinemachineTransposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        _targetFollowOffset = _cinemachineTransposer.m_FollowOffset;

    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// Handle camera movement based on keyboard inputs W, A, S, and D.
    /// </summary>
    private void HandleMovement()
    {
        Vector3 inputMoveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z -= 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x += 1f;
        }

        Vector3 moveVector = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x;
        transform.position += moveVector * (_moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Handle camera rotation based on keyboard inputs Q and E.
    /// </summary>
    private void HandleRotation()
    {
        Vector3 rotationVector = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y -= 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y += 1f;
        }

        transform.eulerAngles += rotationVector * (_rotationSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Handle camera zoom based on mouse scroll wheel.
    /// </summary>
    private void HandleZoom()
    {

        if(Input.mouseScrollDelta.y > 0)
        {
            _targetFollowOffset.y -= _zoomAmount;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            _targetFollowOffset.y += _zoomAmount;
        }

        _targetFollowOffset.y = Mathf.Clamp(_targetFollowOffset.y, MIN_FOLLOW_OFFSET_Y, MAX_FOLLOW_OFFSET_Y);

        _cinemachineTransposer.m_FollowOffset = Vector3.Lerp(_cinemachineTransposer.m_FollowOffset, _targetFollowOffset, Time.deltaTime * _zoomSpeed);

    }

    #endregion
}