using System;
using TurnBased3DRTS.Actions;
using TurnBased3DRTS.Units;
using UnityEngine;

namespace UI
{
    public class UnitActionSystemUI : MonoBehaviour
    {
        [SerializeField] private Transform _unitActionButtonPrefab;
        [SerializeField] private Transform _unitActionButtonsContainerTransform;

        private void Start()
        {
            UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
            CreateUnitActionButtons();
        }

        private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
        {
            CreateUnitActionButtons();
        }

        private void CreateUnitActionButtons()
        {
            foreach (Transform buttonTransform in _unitActionButtonsContainerTransform)
            {
                Destroy(buttonTransform.gameObject);
            }

            Unit selectedUnit = UnitActionSystem.Instance.SelectedUnit;

            foreach (BaseAction baseAction in selectedUnit.GetBaseActionsArray())
            {
                Transform unitActionButtonTransform = Instantiate(_unitActionButtonPrefab, _unitActionButtonsContainerTransform);
                ActionButtonUI actionButtonUI = unitActionButtonTransform.GetComponent<ActionButtonUI>();
                actionButtonUI.SetBaseAction(baseAction);
            }
        }
    }
}
