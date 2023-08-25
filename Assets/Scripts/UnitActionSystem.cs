using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if(TryHandleUnitSelection()) return;

            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask("Units")))
        {
            if(hit.collider.TryGetComponent(out Unit clickedUnit))
            {
                selectedUnit = clickedUnit;
                return true;
            }
        }
        return false;
    }
}
