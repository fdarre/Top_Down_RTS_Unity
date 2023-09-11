using UnityEngine;

/// <summary>
/// The CameraController class allows for keyboard-driven movement and rotation of the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    #region Fields

    // Movement and rotation speeds can be made adjustable,
    // but for the purpose of this example, they are set as constants.
    private const float MOVE_SPEED = 11f;
    private const float ROTATION_SPEED = 90f;

    #endregion

    #region Unity Methods

    private void Update()
    {
        HandleMovement();
        HandleRotation();
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
        transform.position += moveVector * (MOVE_SPEED * Time.deltaTime);
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

        transform.eulerAngles += rotationVector * (ROTATION_SPEED * Time.deltaTime);
    }

    #endregion
}