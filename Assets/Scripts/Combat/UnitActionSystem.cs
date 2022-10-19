using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instance { get; private set; }

    [SerializeField]private Unit selectedUnit;
    [SerializeField] private LayerMask UnitLayerMask;

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
        

        if (Input.GetMouseButtonDown(0))
        {
            if(TryHandleUnitSelection()) return;

            selectedUnit.Move(MouseWorldPos.GetPosition());
        }
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
