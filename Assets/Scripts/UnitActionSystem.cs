using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instance { get; private set; }

    public Unit selectedUnit { get; private set; }

    public event EventHandler OnSelectedUnitChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one unit action system.");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        selectedUnit = FindAnyObjectByType<Unit>();
    }


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
                SetSelectedUnit(clickedUnit);
                return true;
            }
        }
        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        //Null check to avoid null reference exception if there is no event subscribers
        if (OnSelectedUnitChanged != null)
        {
            OnSelectedUnitChanged(this, EventArgs.Empty);
        }
    }

}