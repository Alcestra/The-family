using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instance { get; private set; }

    [SerializeField]private Unit selectedUnit;
    [SerializeField] private LayerMask UnitLayerMask;

    private bool isBusy;

    public event EventHandler onSelectedUnitChanged;

    private void Awake()
    {
        if(Instance != null)
        {
             Destroy(Instance.gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (isBusy)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(TryHandleUnitSelection()) return;
            //checking if the mouse is inside the grid space so that the move promt has a valid position

            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorldPos.GetPosition());

            if (selectedUnit.GetMoveAction().IsValidActionGridPostition(mouseGridPosition))
            {
                SetBusy();
                selectedUnit.GetMoveAction().Move(mouseGridPosition,ClearBusy);
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            SetBusy();
            selectedUnit.GetSpinAction().Spin(ClearBusy);
        }
    }

    private void SetBusy()
    {
        isBusy = true;
    }

    private void ClearBusy()
    {
        isBusy = false;
    }

    
    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, UnitLayerMask))
        {
            if(raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                setSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void setSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        onSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;   
    }

}
