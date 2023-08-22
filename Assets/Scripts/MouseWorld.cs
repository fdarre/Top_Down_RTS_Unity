using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    #region Public Methods

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("MousePlane")))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    #endregion

    #region Initialization

    private void Awake()
    {
        _instance = this;
        _mousePlaneLayerMask = LayerMask.GetMask("MousePlane");
    }

    #endregion

    #region Update

    private void Update()
    {
        transform.position = GetPosition();
    }

    #endregion

    #region Private Fields

    private static MouseWorld _instance;
    private LayerMask _mousePlaneLayerMask;

    #endregion
}
